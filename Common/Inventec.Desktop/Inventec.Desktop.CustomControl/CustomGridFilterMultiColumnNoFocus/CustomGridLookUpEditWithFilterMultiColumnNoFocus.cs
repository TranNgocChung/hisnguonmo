using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Popup;

namespace Inventec.Desktop.CustomControl.NoFocus
{
    [UserRepositoryItem("RegisterCustomGridLookUpEdit")]
    public class RepositoryItemCustomGridLookUpEditNoFocus : RepositoryItemGridLookUpEdit
    {
        static RepositoryItemCustomGridLookUpEditNoFocus() { RegisterCustomGridLookUpEdit(); }

        public RepositoryItemCustomGridLookUpEditNoFocus()
        {
            TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            AutoComplete = false;
        }
        [Browsable(false)]
        public override DevExpress.XtraEditors.Controls.TextEditStyles TextEditStyle { get { return base.TextEditStyle; } set { base.TextEditStyle = value; } }
        public const string CustomGridLookUpEditName = "CustomGridLookUpEditWithFilterMultiColumnNoFocus";

        public override string EditorTypeName { get { return CustomGridLookUpEditName; } }

        public static void RegisterCustomGridLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomGridLookUpEditName,
              typeof(CustomGridLookUpEditWithFilterMultiColumnNoFocus), typeof(RepositoryItemCustomGridLookUpEditNoFocus),
              typeof(GridLookUpEditBaseViewInfo), new ButtonEditPainter(), true));
        }

        protected override GridView CreateViewInstance() { return new CustomGridViewWithFilterMultiColumnNoFocus(); }
        protected override GridControl CreateGrid() { return new CustomGridControlWithFilterMultiColumnNoFocus(); }
    }


    public class CustomGridLookUpEditWithFilterMultiColumnNoFocus : GridLookUpEdit
    {       
        static CustomGridLookUpEditWithFilterMultiColumnNoFocus() { RepositoryItemCustomGridLookUpEditNoFocus.RegisterCustomGridLookUpEdit(); }

        public CustomGridLookUpEditWithFilterMultiColumnNoFocus() : base() { }

        public override string EditorTypeName { get { return RepositoryItemCustomGridLookUpEditNoFocus.CustomGridLookUpEditName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomGridLookUpEditNoFocus Properties { get { return base.Properties as RepositoryItemCustomGridLookUpEditNoFocus; } }

        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm() // NEW
        {
            return new MyGridLookUpPopupFormNoFocus(this);
        }

        public override bool IsNeededKey(System.Windows.Forms.KeyEventArgs e)
        {
            return Properties.IsNeededKey(e.KeyData);
        }

        protected override bool IsAutoComplete
        {
            get
            {
                return true;
            }
        }
    }

    public class MyGridLookUpPopupFormNoFocus : PopupGridLookUpEditForm // NEW
    {
        public MyGridLookUpPopupFormNoFocus(GridLookUpEdit ownerEdit)
            : base(ownerEdit)
        {
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                OwnerEdit.EditValue = QueryResultValue();
                this.OwnerEdit.SendKey(e);
            }
            base.OnKeyDown(e);
        }
    }
}
