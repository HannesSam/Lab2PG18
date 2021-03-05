﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrescriptionClient.PrescriptionServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PrescriptionServiceReference.IWCFService")]
    public interface IWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/GetTestData", ReplyAction="http://tempuri.org/IWCFService/GetTestDataResponse")]
        System.Xml.Linq.XElement GetTestData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/GetTestData", ReplyAction="http://tempuri.org/IWCFService/GetTestDataResponse")]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetTestDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/GetAllInterchanges", ReplyAction="http://tempuri.org/IWCFService/GetAllInterchangesResponse")]
        System.Xml.Linq.XElement GetAllInterchanges();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/GetAllInterchanges", ReplyAction="http://tempuri.org/IWCFService/GetAllInterchangesResponse")]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetAllInterchangesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeID", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeIDResponse")]
        System.Xml.Linq.XElement FilterByInterchangeID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeID", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeIDResponse")]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeIDAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeNode", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeNodeResponse")]
        System.Xml.Linq.XElement FilterByInterchangeNode(string node);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeNode", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeNodeResponse")]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeNodeAsync(string node);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeIDAndNode", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeIDAndNodeResponse")]
        System.Xml.Linq.XElement FilterByInterchangeIDAndNode(int id, string node);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeIDAndNode", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeIDAndNodeResponse")]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeIDAndNodeAsync(int id, string node);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeNodeValue", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeNodeValueResponse")]
        System.Xml.Linq.XElement FilterByInterchangeNodeValue(string node, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FilterByInterchangeNodeValue", ReplyAction="http://tempuri.org/IWCFService/FilterByInterchangeNodeValueResponse")]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeNodeValueAsync(string node, string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFServiceChannel : PrescriptionClient.PrescriptionServiceReference.IWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFServiceClient : System.ServiceModel.ClientBase<PrescriptionClient.PrescriptionServiceReference.IWCFService>, PrescriptionClient.PrescriptionServiceReference.IWCFService {
        
        public WCFServiceClient() {
        }
        
        public WCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Xml.Linq.XElement GetTestData() {
            return base.Channel.GetTestData();
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetTestDataAsync() {
            return base.Channel.GetTestDataAsync();
        }
        
        public System.Xml.Linq.XElement GetAllInterchanges() {
            return base.Channel.GetAllInterchanges();
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetAllInterchangesAsync() {
            return base.Channel.GetAllInterchangesAsync();
        }
        
        public System.Xml.Linq.XElement FilterByInterchangeID(int id) {
            return base.Channel.FilterByInterchangeID(id);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeIDAsync(int id) {
            return base.Channel.FilterByInterchangeIDAsync(id);
        }
        
        public System.Xml.Linq.XElement FilterByInterchangeNode(string node) {
            return base.Channel.FilterByInterchangeNode(node);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeNodeAsync(string node) {
            return base.Channel.FilterByInterchangeNodeAsync(node);
        }
        
        public System.Xml.Linq.XElement FilterByInterchangeIDAndNode(int id, string node) {
            return base.Channel.FilterByInterchangeIDAndNode(id, node);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeIDAndNodeAsync(int id, string node) {
            return base.Channel.FilterByInterchangeIDAndNodeAsync(id, node);
        }
        
        public System.Xml.Linq.XElement FilterByInterchangeNodeValue(string node, string value) {
            return base.Channel.FilterByInterchangeNodeValue(node, value);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> FilterByInterchangeNodeValueAsync(string node, string value) {
            return base.Channel.FilterByInterchangeNodeValueAsync(node, value);
        }
    }
}
