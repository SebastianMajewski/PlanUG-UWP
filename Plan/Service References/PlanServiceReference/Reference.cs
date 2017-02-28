﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace Plan.PlanServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Change", Namespace="http://schemas.datacontract.org/2004/07/PlanService.DataClasses")]
    public partial class Change : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ChangesField;
        
        private Plan.PlanServiceReference.ClassesType ClassesTypeField;
        
        private string GroupField;
        
        private string LecturerField;
        
        private string SubjectField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Changes {
            get {
                return this.ChangesField;
            }
            set {
                if ((object.ReferenceEquals(this.ChangesField, value) != true)) {
                    this.ChangesField = value;
                    this.RaisePropertyChanged("Changes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Plan.PlanServiceReference.ClassesType ClassesType {
            get {
                return this.ClassesTypeField;
            }
            set {
                if ((this.ClassesTypeField.Equals(value) != true)) {
                    this.ClassesTypeField = value;
                    this.RaisePropertyChanged("ClassesType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Group {
            get {
                return this.GroupField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupField, value) != true)) {
                    this.GroupField = value;
                    this.RaisePropertyChanged("Group");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Lecturer {
            get {
                return this.LecturerField;
            }
            set {
                if ((object.ReferenceEquals(this.LecturerField, value) != true)) {
                    this.LecturerField = value;
                    this.RaisePropertyChanged("Lecturer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClassesType", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Enums")]
    public enum ClassesType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Laboratories = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Practices = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Lectures = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Seminars = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Faculties = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Internships = 5,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Exceptions")]
    public partial class ServiceFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string InvarianStringField;
        
        private string MessageField;
        
        private Plan.PlanServiceReference.ErrorType TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InvarianString {
            get {
                return this.InvarianStringField;
            }
            set {
                if ((object.ReferenceEquals(this.InvarianStringField, value) != true)) {
                    this.InvarianStringField = value;
                    this.RaisePropertyChanged("InvarianString");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Plan.PlanServiceReference.ErrorType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ErrorType", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Enums")]
    public enum ErrorType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PlanWebsiteError = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        JsonParsingError = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PlanWebsiteRequestError = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ForStudiesOptionsHtmlParsingError = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        YearAndFieldParsingError = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SpecializationsParsingError = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GroupAndLectoratesParsingError = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddressBuildError = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ClassesParsingError = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ClassesMergeError = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SeminarHtmlParsingError = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FacultyHtmlParsingError = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ChangesHtmlParsingError = 13,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Classes", Namespace="http://schemas.datacontract.org/2004/07/PlanService.DataClasses")]
    public partial class Classes : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CommentsField;
        
        private string DateToField;
        
        private Plan.PlanServiceReference.Day DayField;
        
        private string GroupField;
        
        private string HourFromField;
        
        private string HourToField;
        
        private string LecturerField;
        
        private string RoomField;
        
        private string SubjectField;
        
        private Plan.PlanServiceReference.ClassesType TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comments {
            get {
                return this.CommentsField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentsField, value) != true)) {
                    this.CommentsField = value;
                    this.RaisePropertyChanged("Comments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DateTo {
            get {
                return this.DateToField;
            }
            set {
                if ((object.ReferenceEquals(this.DateToField, value) != true)) {
                    this.DateToField = value;
                    this.RaisePropertyChanged("DateTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Plan.PlanServiceReference.Day Day {
            get {
                return this.DayField;
            }
            set {
                if ((this.DayField.Equals(value) != true)) {
                    this.DayField = value;
                    this.RaisePropertyChanged("Day");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Group {
            get {
                return this.GroupField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupField, value) != true)) {
                    this.GroupField = value;
                    this.RaisePropertyChanged("Group");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HourFrom {
            get {
                return this.HourFromField;
            }
            set {
                if ((object.ReferenceEquals(this.HourFromField, value) != true)) {
                    this.HourFromField = value;
                    this.RaisePropertyChanged("HourFrom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HourTo {
            get {
                return this.HourToField;
            }
            set {
                if ((object.ReferenceEquals(this.HourToField, value) != true)) {
                    this.HourToField = value;
                    this.RaisePropertyChanged("HourTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Lecturer {
            get {
                return this.LecturerField;
            }
            set {
                if ((object.ReferenceEquals(this.LecturerField, value) != true)) {
                    this.LecturerField = value;
                    this.RaisePropertyChanged("Lecturer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Room {
            get {
                return this.RoomField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomField, value) != true)) {
                    this.RoomField = value;
                    this.RaisePropertyChanged("Room");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Plan.PlanServiceReference.ClassesType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Day", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Enums")]
    public enum Day : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Monday = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Tuesday = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Wednesday = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Thursday = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Friday = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Saturday = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sunday = 6,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlanSelect", Namespace="http://schemas.datacontract.org/2004/07/PlanService.DataClasses")]
    public partial class PlanSelect : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string LinkSuffixField;
        
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LinkSuffix {
            get {
                return this.LinkSuffixField;
            }
            set {
                if ((object.ReferenceEquals(this.LinkSuffixField, value) != true)) {
                    this.LinkSuffixField = value;
                    this.RaisePropertyChanged("LinkSuffix");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PlanServiceReference.IPlanServices")]
    public interface IPlanServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanServices/Changes", ReplyAction="http://tempuri.org/IPlanServices/ChangesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Plan.PlanServiceReference.ServiceFault), Action="http://tempuri.org/IPlanServices/ChangesServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Exceptions")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Change>> ChangesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanServices/Seminars", ReplyAction="http://tempuri.org/IPlanServices/SeminarsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Plan.PlanServiceReference.ServiceFault), Action="http://tempuri.org/IPlanServices/SeminarsServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Exceptions")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Classes>> SeminarsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanServices/Faculties", ReplyAction="http://tempuri.org/IPlanServices/FacultiesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Plan.PlanServiceReference.ServiceFault), Action="http://tempuri.org/IPlanServices/FacultiesServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Exceptions")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Classes>> FacultiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanServices/StudiesSelects", ReplyAction="http://tempuri.org/IPlanServices/StudiesSelectsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Plan.PlanServiceReference.ServiceFault), Action="http://tempuri.org/IPlanServices/StudiesSelectsServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Exceptions")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.PlanSelect>> StudiesSelectsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPlanServices/PlanForStudies", ReplyAction="http://tempuri.org/IPlanServices/PlanForStudiesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Plan.PlanServiceReference.ServiceFault), Action="http://tempuri.org/IPlanServices/PlanForStudiesServiceFaultFault", Name="ServiceFault", Namespace="http://schemas.datacontract.org/2004/07/PlanService.Exceptions")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Classes>> PlanForStudiesAsync(Plan.PlanServiceReference.PlanSelect select);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlanServicesChannel : Plan.PlanServiceReference.IPlanServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlanServicesClient : System.ServiceModel.ClientBase<Plan.PlanServiceReference.IPlanServices>, Plan.PlanServiceReference.IPlanServices {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public PlanServicesClient() : 
                base(PlanServicesClient.GetDefaultBinding(), PlanServicesClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IPlanServices.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PlanServicesClient(EndpointConfiguration endpointConfiguration) : 
                base(PlanServicesClient.GetBindingForEndpoint(endpointConfiguration), PlanServicesClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PlanServicesClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PlanServicesClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PlanServicesClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(PlanServicesClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PlanServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Change>> ChangesAsync() {
            return base.Channel.ChangesAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Classes>> SeminarsAsync() {
            return base.Channel.SeminarsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Classes>> FacultiesAsync() {
            return base.Channel.FacultiesAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.PlanSelect>> StudiesSelectsAsync() {
            return base.Channel.StudiesSelectsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Plan.PlanServiceReference.Classes>> PlanForStudiesAsync(Plan.PlanServiceReference.PlanSelect select) {
            return base.Channel.PlanForStudiesAsync(select);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPlanServices)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPlanServices)) {
                return new System.ServiceModel.EndpointAddress("http://planugservice.azurewebsites.net/PlanServices.svc/soap");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return PlanServicesClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IPlanServices);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return PlanServicesClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IPlanServices);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IPlanServices,
        }
    }
}