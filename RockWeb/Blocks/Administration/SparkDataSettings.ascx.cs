﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock;
using Rock.Cache;
using Rock.Data;
using Rock.Model;
using Rock.SystemKey;
using Rock.Utility.Settings.SparkData;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Blocks.Administration
{
    /// <summary>
    /// Spark Data Settings
    /// </summary>
    [DisplayName( "Spark Data Settings" )]
    [Category( "Administration" )]
    [Description( "Block used to set values specific to Spark Data (NCOA, Etc)." )]
    public partial class SparkDataSettings : RockBlock
    {
        #region private variables

        private RockContext _rockContext = new RockContext();

        private SparkDataConfig _sparkDataConfig = new SparkDataConfig();
        #endregion

        #region Base Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            // this event gets fired after block settings are updated. it's nice to repaint the screen if these settings would alter it
            this.BlockUpdated += Block_BlockUpdated;
            this.AddConfigurationUpdateTrigger( upnlContent );
            dvpPersonDataView.EntityTypeId = CacheEntityType.GetId<Rock.Model.Person>();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                BindControls();
                GetSettings();
                SetPanels();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the BlockUpdated event of the SystemConfiguration control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Block_BlockUpdated( object sender, EventArgs e )
        {
        }

        /// <summary>
        /// Handles saving all the data set by the user to the web.config.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bbtnSaveConfig_Click( object sender, EventArgs e )
        {
            if ( !Page.IsValid )
            {
                return;
            }

            SaveSettings();
        }

        /// <summary>
        /// Handles the CheckedChanged event when enabling/disabling a Spark Data option.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void cbSparkDataEnabled_CheckedChanged( object sender, EventArgs e )
        {
            SetPanels();
        }

        /// <summary>
        /// Handles the CheckedChanged event when enabling/disabling the recurring enabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void cbRecurringEnabled_CheckedChanged( object sender, EventArgs e )
        {
            nbRecurrenceInterval.Enabled = cbRecurringEnabled.Checked;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Binds the controls.
        /// </summary>
        private void BindControls()
        {
        }

        /// <summary>
        /// Enables the data automation panels and sets the titles.
        /// </summary>
        private void SetPanels()
        {
            SetPanel( pwNcoaConfiguration, pnlNcoaConfiguration, "National Change of Address (NCOA)", cbNcoaConfiguration.Checked );
        }

        /// <summary>
        /// Enables a data automation panel and sets the title.
        /// </summary>
        /// <param name="panelWidget">The panel widget.</param>
        /// <param name="panel">The panel.</param>
        /// <param name="title">The title.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        private void SetPanel( PanelWidget panelWidget, Panel panel, string title, bool enabled )
        {
            panel.Enabled = enabled;
            var enabledLabel = string.Empty;
            if ( enabled )
            {
                enabledLabel = "<span class='label label-success'>Enabled</span>";
            }
            else
            {
                enabledLabel = "<span class='label label-warning'>Disabled</span>";
            }

            panelWidget.Title = string.Format( "<h3 class='panel-title pull-left margin-r-sm'>{0}</h3> <div class='pull-right'>{1}</div>", title, enabledLabel );
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        private void GetSettings()
        {
            // Get Ncoa configuration settings
            nbMinMoveDistance.Text = Rock.Web.SystemSettings.GetValue( SystemSetting.NCOA_MINIMUM_MOVE_DISTANCE_TO_INACTIVATE );
            cb48MonAsPrevious.Checked = Rock.Web.SystemSettings.GetValue( SystemSetting.NCOA_SET_48_MONTH_AS_PREVIOUS ).AsBoolean();
            cbInvalidAddressAsPrevious.Checked = Rock.Web.SystemSettings.GetValue( SystemSetting.NCOA_SET_INVALID_AS_PREVIOUS ).AsBoolean();

            // Get Spark Data settings
            _sparkDataConfig = Rock.Web.SystemSettings.GetValue( SystemSetting.SPARK_DATA ).FromJsonOrNull<SparkDataConfig>() ?? new SparkDataConfig();

            if ( _sparkDataConfig == null )
            {
                _sparkDataConfig = new SparkDataConfig();
            }

            txtSparkDataApiKey.Text = _sparkDataConfig.SparkDataApiKey;
            grpNotificationGroup.GroupId = _sparkDataConfig.GlobalNotificationApplicationGroupId;

            // Get NCOA settings
            if ( _sparkDataConfig.NcoaSettings == null )
            {
                _sparkDataConfig.NcoaSettings = new NcoaSettings();
            }

            dvpPersonDataView.SelectedValue = _sparkDataConfig.NcoaSettings.PersonDataViewId.ToStringSafe();
            cbRecurringEnabled.Checked = _sparkDataConfig.NcoaSettings.RecurringEnabled;
            nbRecurrenceInterval.Enabled = _sparkDataConfig.NcoaSettings.RecurringEnabled;
            nbRecurrenceInterval.Text = _sparkDataConfig.NcoaSettings.RecurrenceInterval.ToStringSafe();
            cbNcoaConfiguration.Checked = _sparkDataConfig.NcoaSettings.IsEnabled;
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            // Ncoa Configuration
            Rock.Web.SystemSettings.SetValue( SystemSetting.NCOA_MINIMUM_MOVE_DISTANCE_TO_INACTIVATE, nbMinMoveDistance.Text );
            Rock.Web.SystemSettings.SetValue( SystemSetting.NCOA_SET_48_MONTH_AS_PREVIOUS, cb48MonAsPrevious.Checked.ToString() );
            Rock.Web.SystemSettings.SetValue( SystemSetting.NCOA_SET_INVALID_AS_PREVIOUS, cbInvalidAddressAsPrevious.Checked.ToString() );

            // Save Spark Data
            _sparkDataConfig = new SparkDataConfig();
            _sparkDataConfig.GlobalNotificationApplicationGroupId = grpNotificationGroup.GroupId;
            _sparkDataConfig.SparkDataApiKey = txtSparkDataApiKey.Text;

            // Save NCOA settings
            _sparkDataConfig.NcoaSettings = new NcoaSettings();
            _sparkDataConfig.NcoaSettings.PersonDataViewId = dvpPersonDataView.SelectedValue.AsIntegerOrNull();
            _sparkDataConfig.NcoaSettings.RecurringEnabled = cbRecurringEnabled.Checked;
            _sparkDataConfig.NcoaSettings.RecurrenceInterval = nbRecurrenceInterval.Text.AsInteger();
            _sparkDataConfig.NcoaSettings.IsEnabled = cbNcoaConfiguration.Checked;

            Rock.Web.SystemSettings.SetValue( SystemSetting.SPARK_DATA, _sparkDataConfig.ToJson() );

            // Save job active status
            using ( var rockContext = new RockContext() )
            {
                var ncoaJob = new ServiceJobService( rockContext ).Get( Rock.SystemGuid.ServiceJob.GET_NCOA.AsGuid() );
                if ( ncoaJob != null )
                {
                    ncoaJob.IsActive = cbNcoaConfiguration.Checked;
                    rockContext.SaveChanges();
                }
            }

        }

        #endregion
    }
}