namespace MedCreda.Mvc.App_Start {
    internal class HostAuthenticationFilter {
        private string authenticationType;

        public HostAuthenticationFilter(string authenticationType) {
            this.authenticationType = authenticationType;
        }
    }
}