// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - IBaseViewModel.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:10 AM, 01/04/2013
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
    /// <summary>   Interface for base view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="INotifyPropertyChanged"/>
    /// <seealso cref="IDisposable"/>
    ///=================================================================================================
    public interface IBaseViewModel : INotifyPropertyChanged, IDisposable {
        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the name of the display. </summary>
        ///
        /// <value> The name of the display. </value>
        ///=================================================================================================
        string DisplayName { get; set; }

        #endregion
    }

    ///=================================================================================================
    /// <summary>   Interface for base view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="IBaseViewModel"/>
    ///=================================================================================================
    public interface IBaseViewModel<TDomainObject> : IBaseViewModel {
        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the domain object. </summary>
        ///
        /// <value> The domain object. </value>
        ///=================================================================================================
        TDomainObject DomainObject { get; set; }

        #endregion
    }
}
