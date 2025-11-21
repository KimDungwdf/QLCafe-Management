using System;using System.Drawing;using System.Windows.Forms;using QLCafe.Application.Services;
namespace QLCafe.Presentation.Views.Admin
{
    public class AddProductDialog:Form
    {
        private TextBox txtName;private ComboBox cboCategory;private NumericUpDown nudPrice;private Button btnAdd;private Button btnCancel;private CategoryService _categoryService;
        public string ProductName=>txtName.Text.Trim();public int SelectedCategoryId=>cboCategory.SelectedItem is CategoryItem ci?ci.Id:0;public decimal Price=>nudPrice.Value;
        public AddProductDialog(CategoryService catService){_categoryService=catService;Init();}
        private void Init(){Text="Thêm Món";FormBorderStyle=FormBorderStyle.FixedDialog;StartPosition=FormStartPosition.CenterParent;ClientSize=new Size(400,260);Font=new Font("Segoe UI",9F);
            Label lbl1=new Label{Text="Tên món",Left=20,Top=25,Width=120};txtName=new TextBox{Left=150,Top=22,Width=200};
            Label lbl2=new Label{Text="Danh m?c",Left=20,Top=75,Width=120};cboCategory=new ComboBox{Left=150,Top=72,Width=200,DropDownStyle=ComboBoxStyle.DropDownList};
            Label lbl3=new Label{Text="Giá",Left=20,Top=125,Width=120};nudPrice=new NumericUpDown{Left=150,Top=122,Width=200,Maximum=100000000,Minimum=0,ThousandsSeparator=true,Increment=1000};
            btnAdd=new Button{Text="Thêm",Left=150,Top=180,Width=95,DialogResult=DialogResult.OK};btnCancel=new Button{Text="H?y",Left=255,Top=180,Width=95,DialogResult=DialogResult.Cancel};btnAdd.Click+=BtnAdd_Click;
            Controls.AddRange(new Control[]{lbl1,txtName,lbl2,cboCategory,lbl3,nudPrice,btnAdd,btnCancel});LoadCategories();}
        private void LoadCategories(){cboCategory.Items.Clear();foreach(var c in _categoryService.GetAllPairs())cboCategory.Items.Add(new CategoryItem{Id=c.Id,Text=c.Name});if(cboCategory.Items.Count>0)cboCategory.SelectedIndex=0;}
        private void BtnAdd_Click(object sender,EventArgs e){if(string.IsNullOrWhiteSpace(ProductName)||SelectedCategoryId==0){MessageBox.Show("Nh?p ??y ?? thông tin","L?i",MessageBoxButtons.OK,MessageBoxIcon.Warning);DialogResult=DialogResult.None;}}
        private class CategoryItem{public int Id;public string Text;public override string ToString()=>Text;}
    }
}