// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: zeus_notification_msg.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Zeus.RPC.Protocol
{
    public static partial class NotificationRpcService
    {
        static readonly string __ServiceName = "Zeus.RPC.Protocol.NotificationRpcService";

        static readonly grpc::Marshaller<global::Zeus.RPC.Protocol.NotificationReq> __Marshaller_Zeus_RPC_Protocol_NotificationReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Zeus.RPC.Protocol.NotificationReq.Parser.ParseFrom);
        static readonly grpc::Marshaller<global::Zeus.RPC.Protocol.NotificationResp> __Marshaller_Zeus_RPC_Protocol_NotificationResp = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Zeus.RPC.Protocol.NotificationResp.Parser.ParseFrom);
        static readonly grpc::Marshaller<global::Zeus.RPC.Protocol.NotificationAllReq> __Marshaller_Zeus_RPC_Protocol_NotificationAllReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Zeus.RPC.Protocol.NotificationAllReq.Parser.ParseFrom);

        static readonly grpc::Method<global::Zeus.RPC.Protocol.NotificationReq, global::Zeus.RPC.Protocol.NotificationResp> __Method_Send = new grpc::Method<global::Zeus.RPC.Protocol.NotificationReq, global::Zeus.RPC.Protocol.NotificationResp>(
            grpc::MethodType.Unary,
            __ServiceName,
            "Send",
            __Marshaller_Zeus_RPC_Protocol_NotificationReq,
            __Marshaller_Zeus_RPC_Protocol_NotificationResp);

        static readonly grpc::Method<global::Zeus.RPC.Protocol.NotificationAllReq, global::Zeus.RPC.Protocol.NotificationResp> __Method_SendAll = new grpc::Method<global::Zeus.RPC.Protocol.NotificationAllReq, global::Zeus.RPC.Protocol.NotificationResp>(
            grpc::MethodType.Unary,
            __ServiceName,
            "SendAll",
            __Marshaller_Zeus_RPC_Protocol_NotificationAllReq,
            __Marshaller_Zeus_RPC_Protocol_NotificationResp);

        /// <summary>Service descriptor</summary>
        public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
        {
            get { return global::Zeus.RPC.Protocol.ZeusNotificationMsgReflection.Descriptor.Services[0]; }
        }

        /// <summary>Base class for server-side implementations of NotificationRpcService</summary>
        [grpc::BindServiceMethod(typeof(NotificationRpcService), "BindService")]
        public abstract partial class NotificationRpcServiceBase
        {
            public virtual global::System.Threading.Tasks.Task<global::Zeus.RPC.Protocol.NotificationResp> Send(global::Zeus.RPC.Protocol.NotificationReq request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

            public virtual global::System.Threading.Tasks.Task<global::Zeus.RPC.Protocol.NotificationResp> SendAll(global::Zeus.RPC.Protocol.NotificationAllReq request, grpc::ServerCallContext context)
            {
                throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
            }

        }

        /// <summary>Client for NotificationRpcService</summary>
        public partial class NotificationRpcServiceClient : grpc::ClientBase<NotificationRpcServiceClient>
        {
            /// <summary>Creates a new client for NotificationRpcService</summary>
            /// <param name="channel">The channel to use to make remote calls.</param>
            public NotificationRpcServiceClient(grpc::ChannelBase channel) : base(channel)
            {
            }
            /// <summary>Creates a new client for NotificationRpcService that uses a custom <c>CallInvoker</c>.</summary>
            /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
            public NotificationRpcServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
            {
            }
            /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
            protected NotificationRpcServiceClient() : base()
            {
            }
            /// <summary>Protected constructor to allow creation of configured clients.</summary>
            /// <param name="configuration">The client configuration.</param>
            protected NotificationRpcServiceClient(ClientBaseConfiguration configuration) : base(configuration)
            {
            }

            public virtual global::Zeus.RPC.Protocol.NotificationResp Send(global::Zeus.RPC.Protocol.NotificationReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
            {
                return Send(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }
            public virtual global::Zeus.RPC.Protocol.NotificationResp Send(global::Zeus.RPC.Protocol.NotificationReq request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_Send, null, options, request);
            }
            public virtual grpc::AsyncUnaryCall<global::Zeus.RPC.Protocol.NotificationResp> SendAsync(global::Zeus.RPC.Protocol.NotificationReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
            {
                return SendAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }
            public virtual grpc::AsyncUnaryCall<global::Zeus.RPC.Protocol.NotificationResp> SendAsync(global::Zeus.RPC.Protocol.NotificationReq request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_Send, null, options, request);
            }
            public virtual global::Zeus.RPC.Protocol.NotificationResp SendAll(global::Zeus.RPC.Protocol.NotificationAllReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
            {
                return SendAll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }
            public virtual global::Zeus.RPC.Protocol.NotificationResp SendAll(global::Zeus.RPC.Protocol.NotificationAllReq request, grpc::CallOptions options)
            {
                return CallInvoker.BlockingUnaryCall(__Method_SendAll, null, options, request);
            }
            public virtual grpc::AsyncUnaryCall<global::Zeus.RPC.Protocol.NotificationResp> SendAllAsync(global::Zeus.RPC.Protocol.NotificationAllReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
            {
                return SendAllAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
            }
            public virtual grpc::AsyncUnaryCall<global::Zeus.RPC.Protocol.NotificationResp> SendAllAsync(global::Zeus.RPC.Protocol.NotificationAllReq request, grpc::CallOptions options)
            {
                return CallInvoker.AsyncUnaryCall(__Method_SendAll, null, options, request);
            }
            /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
            protected override NotificationRpcServiceClient NewInstance(ClientBaseConfiguration configuration)
            {
                return new NotificationRpcServiceClient(configuration);
            }
        }

        /// <summary>Creates service definition that can be registered with a server</summary>
        /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
        public static grpc::ServerServiceDefinition BindService(NotificationRpcServiceBase serviceImpl)
        {
            return grpc::ServerServiceDefinition.CreateBuilder()
                .AddMethod(__Method_Send, serviceImpl.Send)
                .AddMethod(__Method_SendAll, serviceImpl.SendAll).Build();
        }

        /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
        /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
        /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
        /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
        public static void BindService(grpc::ServiceBinderBase serviceBinder, NotificationRpcServiceBase serviceImpl)
        {
            serviceBinder.AddMethod(__Method_Send, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Zeus.RPC.Protocol.NotificationReq, global::Zeus.RPC.Protocol.NotificationResp>(serviceImpl.Send));
            serviceBinder.AddMethod(__Method_SendAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Zeus.RPC.Protocol.NotificationAllReq, global::Zeus.RPC.Protocol.NotificationResp>(serviceImpl.SendAll));
        }

    }
}
#endregion
