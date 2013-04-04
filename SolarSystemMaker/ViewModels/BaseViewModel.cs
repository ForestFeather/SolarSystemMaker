// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - BaseViewModel.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:18 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System;
using System.ComponentModel;

#endregion

namespace SolarSystemMaker.ViewModels {
    ///=================================================================================================
    /// <summary>   Base view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel"/>
    ///=================================================================================================
    public class BaseViewModel : IBaseViewModel {
        #region Implementation of INotifyPropertyChanged

        /// <summary>   Name of the display. </summary>
        private string _displayName;

        /// <summary>   Event queue for all listeners interested in PropertyChanged events. </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Implementation of IDisposable

        ///=================================================================================================
        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        ///
        /// <remarks>   Cdo, 4/1/2013. </remarks>
        ///=================================================================================================
        public void Dispose( ) {
            this.OnDispose( true );
            GC.SuppressFinalize( this );
        }

        #endregion

        #region Implementation of IBaseViewModel

        ///=================================================================================================
        /// <summary>   Gets or sets the name of the display. </summary>
        ///
        /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel.DisplayName"/>
        ///
        /// ### <value> The name of the display. </value>
        ///=================================================================================================
        public string DisplayName {
            get { return this._displayName; }
            set {
                if ( this._displayName != value ) {
                    this._displayName = value;
                    this.OnPropertyChanged( "DisplayName" );
                }
            }
        }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Executes the dispose action. </summary>
        ///
        /// <remarks>
        ///     Inside goes: <c>if(dispose){//disposableresources} //nondisposableresources</c>
        /// </remarks>
        ///
        /// <param name="dispose">  true to dispose. </param>
        ///=================================================================================================
        protected virtual void OnDispose( bool dispose ) {}

        ///=================================================================================================
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Cdo, 4/1/2013. </remarks>
        ///
        /// <param name="propertyName"> Name of the property. </param>
        ///=================================================================================================
        protected void OnPropertyChanged( string propertyName ) {
            var handler = this.PropertyChanged;
            if ( handler == null ) {
                return;
            }
            var e = new PropertyChangedEventArgs( propertyName );
            handler( this, e );
        }

        #endregion
    }
}
