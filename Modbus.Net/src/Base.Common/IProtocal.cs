﻿using System;
using System.Threading.Tasks;

namespace Modbus.Net
{
    /// <summary>
    ///     协议接口
    /// </summary>
    /// <typeparam name="TParamIn">向Connector传入的类型</typeparam>
    /// <typeparam name="TParamOut">从Connector返回的类型</typeparam>
    /// <typeparam name="TProtocalUnit">协议单元的类型</typeparam>
    public interface IProtocol<TParamIn, TParamOut, TProtocalUnit>
        where TProtocalUnit : IProtocalFormatting<TParamIn, TParamOut>
    {
        /// <summary>
        ///     Wrapper over the transport instance.
        /// </summary>
        IProtocalLinker<TParamIn, TParamOut> ProtocalLinker { get; }

        /// <summary>
        /// Operations to perform on the node
        /// </summary>
        TProtocalUnit this[Type type] { get; }

        /// <summary>
        ///     协议连接开始
        /// </summary>
        /// <returns></returns>
        bool Connect();

        /// <summary>
        ///     协议连接开始（异步）
        /// </summary>
        /// <returns></returns>
        Task<bool> ConnectAsync();

        /// <summary>
        ///     协议连接断开
        /// </summary>
        /// <returns></returns>
        bool Disconnect();

        /// <summary>
        ///     发送协议内容并接收，一般方法
        /// </summary>
        /// <param name="content">写入的内容，使用对象数组描述</param>
        /// <returns>从设备获取的字节流</returns>
        TParamOut SendReceive(params object[] content);

        /// <summary>
        ///     发送协议内容并接收，一般方法
        /// </summary>
        /// <param name="content">写入的内容，使用对象数组描述</param>
        /// <returns>从设备获取的字节流</returns>
        Task<TParamOut> SendReceiveAsync(params object[] content);

        /// <summary>
        ///     发送协议，通过传入需要使用的协议内容和输入结构
        /// </summary>
        /// <param name="unit">协议的实例</param>
        /// <param name="content">输入信息的结构化描述</param>
        /// <returns>输出信息的结构化描述</returns>
        IOutputStruct SendReceive(TProtocalUnit unit, IInputStruct content);

        /// <summary>
        ///     发送协议，通过传入需要使用的协议内容和输入结构
        /// </summary>
        /// <param name="unit">协议的实例</param>
        /// <param name="content">输入信息的结构化描述</param>
        /// <returns>输出信息的结构化描述</returns>
        Task<IOutputStruct> SendReceiveAsync(TProtocalUnit unit, IInputStruct content);

        /// <summary>
        ///     发送协议，通过传入需要使用的协议内容和输入结构
        /// </summary>
        /// <param name="unit">协议的实例</param>
        /// <param name="content">输入信息的结构化描述</param>
        /// <returns>输出信息的结构化描述</returns>
        /// <typeparam name="T">IOutputStruct的具体类型</typeparam>
        T SendReceive<T>(TProtocalUnit unit, IInputStruct content) where T : class, IOutputStruct;

        /// <summary>
        ///     发送协议，通过传入需要使用的协议内容和输入结构
        /// </summary>
        /// <param name="unit">协议的实例</param>
        /// <param name="content">输入信息的结构化描述</param>
        /// <returns>输出信息的结构化描述</returns>
        /// <typeparam name="T">IOutputStruct的具体类型</typeparam>
        Task<T> SendReceiveAsync<T>(TProtocalUnit unit, IInputStruct content) where T : class, IOutputStruct;
    }
}