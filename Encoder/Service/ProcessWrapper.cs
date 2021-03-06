﻿using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace EmergenceGuardian.Encoder.Services {

    #region Interface

    /// <summary>
    /// Abstraction wrapper around the System.Diagnostics.Process class that can be used for unit testing.
    /// </summary>
    public interface IProcess {
        /// <summary>
        /// Gets or sets the overall priority category for the associated process.
        /// </summary>
        ProcessPriorityClass PriorityClass { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the associated process priority should
        /// temporarily be boosted by the operating system when the main window has the focus.
        /// </summary>
        bool PriorityBoostEnabled { get; set; }
        /// <summary>
        /// Gets the maximum amount of virtual memory, in bytes, used by the associated process.
        /// </summary>
        long PeakVirtualMemorySize64 { get; }
        /// <summary>
        /// Gets the maximum amount of physical memory, in bytes, used by the associated process.
        /// </summary>
        long PeakWorkingSet64 { get; }
        /// <summary>
        /// Gets the maximum amount of memory in the virtual memory paging file, in bytes, used by the associated process.
        /// </summary>
        long PeakPagedMemorySize64 { get; }
        /// <summary>
        /// Gets the amount of paged memory, in bytes, allocated for the associated process.
        /// </summary>
        long PagedMemorySize64 { get; }
        /// <summary>
        /// Gets the amount of nonpaged system memory, in bytes, allocated for the associated process.
        /// </summary>
        long NonpagedSystemMemorySize64 { get; }
        /// <summary>
        /// Gets the modules that have been loaded by the associated process.
        /// </summary>
        ProcessModuleCollection Modules { get; }
        /// <summary>
        /// Gets or sets the minimum allowable working set size, in bytes, for the associated process.
        /// </summary>
        IntPtr MinWorkingSet { get; set; }
        /// <summary>
        /// Gets the amount of pageable system memory, in bytes, allocated for the associated process.
        /// </summary>
        long PagedSystemMemorySize64 { get; }
        /// <summary>
        /// Gets the amount of private memory, in bytes, allocated for the associated process.
        /// </summary>
        long PrivateMemorySize64 { get; }
        /// <summary>
        /// Gets the privileged processor time for this process.
        /// </summary>
        TimeSpan PrivilegedProcessorTime { get; }
        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        string ProcessName { get; }
        /// <summary>
        /// Gets the amount of physical memory, in bytes, allocated for the associated process.
        /// </summary>
        long WorkingSet64 { get; }
        /// <summary>
        /// Gets a stream used to read the error output of the application.
        /// </summary>
        StreamReader StandardError { get; }
        /// <summary>
        /// Gets a stream used to read the textual output of the application.
        /// </summary>
        StreamReader StandardOutput { get; }
        /// <summary>
        /// Gets a stream used to write the input of the application.
        /// </summary>
        StreamWriter StandardInput { get; }
        /// <summary>
        /// Gets or sets whether the System.Diagnostics.Process.Exited event should be raised when the process terminates.
        /// </summary>
        bool EnableRaisingEvents { get; set; }
        /// <summary>
        /// Gets the amount of the virtual memory, in bytes, allocated for the associated process.
        /// </summary>
        long VirtualMemorySize64 { get; }
        /// <summary>
        /// Gets the user processor time for this process.
        /// </summary>
        TimeSpan UserProcessorTime { get; }
        /// <summary>
        /// Gets the total processor time for this process.
        /// </summary>
        TimeSpan TotalProcessorTime { get; }
        /// <summary>
        /// Gets the set of threads that are running in the associated process.
        /// </summary>
        ProcessThreadCollection Threads { get; }
        /// <summary>
        /// Gets or sets the object used to marshal the event handler calls that are issued as a result of a process exit event.
        /// </summary>
        ISynchronizeInvoke SynchronizingObject { get; set; }
        /// <summary>
        /// Gets the time that the associated process was started.
        /// </summary>
        DateTime StartTime { get; }
        /// <summary>
        /// Gets or sets the properties to pass to the System.Diagnostics.Process.Start method of the System.Diagnostics.Process.
        /// </summary>
        ProcessStartInfo StartInfo { get; set; }
        /// <summary>
        /// Gets the Terminal Services session identifier for the associated process.
        /// </summary>
        int SessionId { get; }
        /// <summary>
        /// Gets a value indicating whether the user interface of the process is responding.
        /// </summary>
        bool Responding { get; }
        /// <summary>
        /// Gets or sets the processors on which the threads in this process can be scheduled to run.
        /// </summary>
        IntPtr ProcessorAffinity { get; set; }
        /// <summary>
        /// Gets or sets the maximum allowable working set size, in bytes, for the associated process.
        /// </summary>
        IntPtr MaxWorkingSet { get; set; }
        /// <summary>
        /// Gets the main module for the associated process.
        /// </summary>
        ProcessModule MainModule { get; }
        /// <summary>
        /// Gets the caption of the main window of the process.
        /// </summary>
        string MainWindowTitle { get; }
        /// <summary>
        /// Gets the name of the computer the associated process is running on.
        /// </summary>
        string MachineName { get; }
        /// <summary>
        /// Gets the unique identifier for the associated process.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Gets the number of handles opened by the process.
        /// </summary>
        int HandleCount { get; }
        /// <summary>
        /// Gets the native handle to this process.
        /// </summary>
        SafeProcessHandle SafeHandle { get; }
        /// <summary>
        /// Gets the native handle of the associated process.
        /// </summary>
        IntPtr Handle { get; }
        /// <summary>
        /// Gets the time that the associated process exited.
        /// </summary>
        DateTime ExitTime { get; }
        /// <summary>
        /// Gets a value indicating whether the associated process has been terminated.
        /// </summary>
        bool HasExited { get; }
        /// <summary>
        /// Gets the value that the associated process specified when it terminated.
        /// </summary>
        int ExitCode { get; }
        /// <summary>
        /// Gets the base priority of the associated process.
        /// </summary>
        int BasePriority { get; }
        /// <summary>
        /// Gets the window handle of the main window of the associated process.
        /// </summary>
        IntPtr MainWindowHandle { get; }
        /// <summary>
        /// Occurs when an application writes to its redirected System.Diagnostics.Process.StandardError stream.
        /// </summary>
        event DataReceivedEventHandler ErrorDataReceived;
        /// <summary>
        /// Occurs each time an application writes a line to its redirected System.Diagnostics.Process.StandardOutput stream.
        /// </summary>
        event DataReceivedEventHandler OutputDataReceived;
        /// <summary>
        /// Occurs when a process exits.
        /// </summary>
        event EventHandler Exited;
        /// <summary>
        /// Begins asynchronous read operations on the redirected System.Diagnostics.Process.StandardError stream of the application.
        /// </summary>
        void BeginErrorReadLine();
        /// <summary>
        /// Begins asynchronous read operations on the redirected System.Diagnostics.Process.StandardOutput stream of the application.
        /// </summary>
        void BeginOutputReadLine();
        /// <summary>
        /// Cancels the asynchronous read operation on the redirected System.Diagnostics.Process.StandardError stream of an application.
        /// </summary>
        void CancelErrorRead();
        /// <summary>
        /// Cancels the asynchronous read operation on the redirected System.Diagnostics.Process.StandardOutput stream of an application.
        /// </summary>
        void CancelOutputRead();
        /// <summary>
        /// Frees all the resources that are associated with this component.
        /// </summary>
        void Close();
        /// <summary>
        /// Closes a process that has a user interface by sending a close message to its main window.
        /// </summary>
        /// <returns>
        /// true if the close message was successfully sent; false if the associated process
        /// does not have a main window or if the main window is disabled (for example if
        /// a modal dialog is being shown).
        /// </returns>
        bool CloseMainWindow();
        /// <summary>
        /// Immediately stops the associated process.
        /// </summary>
        void Kill();
        /// <summary>
        /// Discards any information about the associated process that has been cached inside the process component.
        /// </summary>
        void Refresh();
        /// <summary>
        /// Starts (or reuses) the process resource that is specified by the System.Diagnostics.Process.StartInfo property 
        /// of this System.Diagnostics.Process component and associates it with the component.
        /// </summary>
        /// <returns>true if a process resource is started; false if no new process resource is started (for example, if an existing process is reused).</returns>
        bool Start();
        /// <summary>
        /// Formats the process's name as a string, combined with the parent component type, if applicable.
        /// </summary>
        /// <returns>The System.Diagnostics.Process.ProcessName, combined with the base component's System.Object.ToString return value.</returns>
        string ToString();
        /// <summary>
        /// Instructs the System.Diagnostics.Process component to wait the specified number of milliseconds for the associated process to exit.
        /// </summary>
        /// <param name="milliseconds">The amount of time, in milliseconds, to wait for the associated process to exit.</param>
        /// <returns>true if the associated process has exited; otherwise, false.</returns>
        bool WaitForExit(int milliseconds);
        /// <summary>
        /// Instructs the System.Diagnostics.Process component to wait indefinitely for the associated process to exit.
        /// </summary>
        void WaitForExit();
        /// <summary>
        /// Causes the System.Diagnostics.Process component to wait the specified number of milliseconds for the associated process 
        /// to enter an idle state. This overload applies only to processes with a user interface and, therefore, a message loop.
        /// </summary>
        /// <param name="milliseconds">A value of 1 to System.Int32.MaxValue that specifies the amount of time, in milliseconds,
        ///   to wait for the associated process to become idle. A value of 0 specifies an
        ///   immediate return, and a value of -1 specifies an infinite wait.</param>
        /// <returns>true if the associated process has reached an idle state; otherwise, false.</returns>
        bool WaitForInputIdle(int milliseconds);
        /// <summary>
        /// Causes the System.Diagnostics.Process component to wait indefinitely for the associated process to enter an idle state. 
        /// This overload applies only to processes with a user interface and, therefore, a message loop.
        /// </summary>
        /// <returns>true if the associated process has reached an idle state.</returns>
        bool WaitForInputIdle();
    }

    #endregion

    /// <summary>
    /// Abstraction wrapper around the System.Diagnostics.Process class that can be used for unit testing.
    /// </summary>
    public class ProcessWrapper : IProcess, IDisposable {
        protected Process process;

        public ProcessWrapper() : this(null) { }

        public ProcessWrapper(Process process) {
            this.process = process ?? new Process();
        }

        public ProcessPriorityClass PriorityClass {
            get => process.PriorityClass;
            set => process.PriorityClass = value;
        }

        public bool PriorityBoostEnabled {
            get => process.PriorityBoostEnabled;
            set => process.PriorityBoostEnabled = value;
        }

        public long PeakVirtualMemorySize64 => process.PeakVirtualMemorySize64;

        public long PeakWorkingSet64 => process.PeakWorkingSet64;

        public long PeakPagedMemorySize64 => process.PeakPagedMemorySize64;

        public long PagedMemorySize64 => process.PagedMemorySize64;

        public long NonpagedSystemMemorySize64 => process.NonpagedSystemMemorySize64;

        public ProcessModuleCollection Modules => process.Modules;

        public IntPtr MinWorkingSet {
            get => process.MinWorkingSet;
            set => process.MinWorkingSet = value;
        }

        public long PagedSystemMemorySize64 => process.PagedSystemMemorySize64;

        public long PrivateMemorySize64 => process.PrivateMemorySize64;

        public TimeSpan PrivilegedProcessorTime => process.PrivilegedProcessorTime;

        public string ProcessName => process.ProcessName;

        public long WorkingSet64 => process.WorkingSet64;

        public StreamReader StandardError => process.StandardError;

        public StreamReader StandardOutput => process.StandardOutput;

        public StreamWriter StandardInput => process.StandardInput;

        public bool EnableRaisingEvents {
            get => process.EnableRaisingEvents;
            set => process.EnableRaisingEvents = value;
        }

        public long VirtualMemorySize64 => process.VirtualMemorySize64;

        public TimeSpan UserProcessorTime => process.UserProcessorTime;

        public TimeSpan TotalProcessorTime => process.TotalProcessorTime;

        public ProcessThreadCollection Threads => process.Threads;

        public ISynchronizeInvoke SynchronizingObject {
            get => process.SynchronizingObject;
            set => process.SynchronizingObject = value;
        }

        public DateTime StartTime => process.StartTime;

        public ProcessStartInfo StartInfo {
            get => process.StartInfo;
            set => process.StartInfo = value;
        }

        public int SessionId => process.SessionId;

        public bool Responding => process.Responding;

        public IntPtr ProcessorAffinity {
            get => process.ProcessorAffinity;
            set => process.ProcessorAffinity = value;
        }

        public IntPtr MaxWorkingSet {
            get => process.MaxWorkingSet;
            set => process.MaxWorkingSet = value;
        }

        public ProcessModule MainModule => process.MainModule;

        public string MainWindowTitle => process.MainWindowTitle;

        public string MachineName => process.MachineName;

        public int Id => process.Id;

        public int HandleCount => process.HandleCount;

        public SafeProcessHandle SafeHandle => process.SafeHandle;

        public IntPtr Handle => process.Handle;

        public DateTime ExitTime => process.ExitTime;

        public bool HasExited => process.HasExited;

        public int ExitCode => process.ExitCode;

        public int BasePriority => process.BasePriority;

        public IntPtr MainWindowHandle => process.MainWindowHandle;

        public event DataReceivedEventHandler ErrorDataReceived {
            add => process.ErrorDataReceived += value;
            remove => process.ErrorDataReceived -= value;
        }

        public event DataReceivedEventHandler OutputDataReceived {
            add => process.OutputDataReceived += value;
            remove => process.OutputDataReceived -= value;
        }

        public event EventHandler Exited {
            add => process.Exited += value;
            remove => process.Exited -= value;
        }

        public void BeginErrorReadLine() {
            process.BeginErrorReadLine();
        }

        public void BeginOutputReadLine() {
            process.BeginOutputReadLine();
        }

        public void CancelErrorRead() {
            process.CancelErrorRead();
        }

        public void CancelOutputRead() {
            process.CancelOutputRead();
        }

        public void Close() {
            process.Close();
        }

        public bool CloseMainWindow() {
            return process.CloseMainWindow();
        }

        public void Kill() {
            process.Kill();
        }

        public void Refresh() {
            throw new NotImplementedException();
        }

        public bool Start() {
            return process.Start();
        }

        public bool WaitForExit(int milliseconds) {
            return process.WaitForExit(milliseconds);
        }

        public void WaitForExit() {
            process.WaitForExit();
        }

        public bool WaitForInputIdle(int milliseconds) {
            return process.WaitForInputIdle(milliseconds);
        }

        public bool WaitForInputIdle() {
            return process.WaitForInputIdle();
        }

        public override string ToString() {
            return process.ToString();
        }

        public void Dispose() {
            process.Dispose();
        }
    }
}
