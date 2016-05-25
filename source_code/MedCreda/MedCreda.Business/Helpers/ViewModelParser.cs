using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Helpers {

    /// <summary>
    /// Generic class parser for ViewModel objects. This transfers data from original model into ViewModel(stripped-down version of Model) - By Sonny
    /// </summary>
    /// <typeparam name="TModel">Original Model / Entity straight from Database</typeparam>
    /// <typeparam name="TViewModel">Stripped-down version of Model for Viewing/Displaying/Editing</typeparam>
    public class ViewModelParser<TModel, TViewModel>
        where TModel : class
        where TViewModel : class, new() {

        private TModel _model;
        private TViewModel _viewModel = new TViewModel();

        /// <summary>
        /// Generic class parser for ViewModel objects. This transfers data from original model into ViewModel(stripped-down version of Model)
        /// </summary>
        /// <typeparam name="TModel">Original Model / Entity straight from Database</typeparam>
        public ViewModelParser(TModel model) {
            //this._viewModel = viewModel;
            this._model = model;
        }

        /// <summary>
        /// Use this when you want to fill in two models. Usually it is used for updating the model state
        /// </summary>
        /// <param name="model">Original Model / Entity straight from Database</param>
        /// <param name="viewModel"></param>
        public ViewModelParser(TModel model, TViewModel viewModel) {
            this._model = model;
            this._viewModel = viewModel;
        }

        /// <summary>
        /// Updates model state for whatever purpose it serves
        /// todo: I normally use this to update the model coming from ViewModel data
        /// </summary>
        /// <returns></returns>
        public TModel UpdateModelState() {

            var viewModelProperties = _viewModel.GetType().GetProperties();
            foreach (PropertyInfo property in viewModelProperties) {

                try {
                    PropertyInfo modelProperty = _model.GetType().GetProperty(property.Name);
                    if (modelProperty == null) {
                        continue;
                    }
                    var modelValue = property.GetValue(_viewModel, null);
                    var valueWithType = Convert.ChangeType(modelValue, property.PropertyType);

                    //todo: we need to filter out null values to avoid leaving the current state of model affected. Don't update the model if the value is null.
                    if (valueWithType != null) {
                        modelProperty.SetValue(_model, valueWithType, null);
                    }
                }
                catch (NullReferenceException ex) {
                    //throw;
                }
                catch (Exception err) {
                    throw;
                    //todo: suppress errors
                }
            }
            return this._model;
        }

        /// <summary>
        /// Initiates data transfer from Model to ViewModel
        /// </summary>
        /// <returns></returns>
        public TViewModel TransferDataToViewModel() {

            var modelProperties = _model.GetType().GetProperties();
            foreach (PropertyInfo property in modelProperties) {

                try {
                    PropertyInfo viewModelProperty = _viewModel.GetType().GetProperty(property.Name);
                    if (viewModelProperty == null) {
                        continue;
                    }
                    var modelValue = property.GetValue(_model, null);
                    if (modelValue == null) {
                        continue;
                    }
                    var valueWithType = Convert.ChangeType(modelValue, viewModelProperty.PropertyType);

                    //todo: we need to filter out null values to avoid leaving the current state of model affected. Don't update the model if the value is null.
                    if (valueWithType != null) {
                        viewModelProperty.SetValue(_viewModel, valueWithType, null);
                    }
                }
                catch (NullReferenceException ex) {
                    //throw;
                }
                catch(InvalidCastException ex) {
                    continue;
                }
            }

            return this._viewModel;
        }

    }
}
