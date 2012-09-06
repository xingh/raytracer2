﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EditorLib;
using RayTracerLib;

namespace _3dEditor
{
    public partial class WndScene : Form
    {
        enum TreeNodeTypes { 
            Objects, Lights, Camera, Images, Animations, // top level nodes
            Spheres, Planes, Cubes, Cylinders}

        public WndScene()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.Selectable, true);

            this.Focus();
            this.Update();

            FillTree();
        }
        /// <summary>
        /// Vyprazdni cely seznam
        /// </summary>
        public void ClearAll()
        {
            this.treeView1.Nodes.Clear();
        }

        private void FillTree()
        {
            TreeNode nodeObjects = new TreeNode(TreeNodeTypes.Objects.ToString());
            nodeObjects.Tag = TreeNodeTypes.Objects;
            
            TreeNode nodeSpheres = new TreeNode(TreeNodeTypes.Spheres.ToString());
            nodeSpheres.Tag = TreeNodeTypes.Spheres;
            TreeNode nodePlanes = new TreeNode(TreeNodeTypes.Planes.ToString());
            nodePlanes.Tag = TreeNodeTypes.Planes;
            TreeNode nodeCubes = new TreeNode(TreeNodeTypes.Cubes.ToString());
            nodeCubes.Tag = TreeNodeTypes.Cubes;
            TreeNode nodeCyls = new TreeNode(TreeNodeTypes.Cylinders.ToString());
            nodeCyls.Tag = TreeNodeTypes.Cylinders;

            nodeObjects.Nodes.Add(nodeSpheres);
            nodeObjects.Nodes.Add(nodePlanes);
            nodeObjects.Nodes.Add(nodeCubes);
            nodeObjects.Nodes.Add(nodeCyls);

            TreeNode nodeLights = new TreeNode(TreeNodeTypes.Lights.ToString());
            nodeLights.Tag = TreeNodeTypes.Lights;

            TreeNode nodeCameras = new TreeNode(TreeNodeTypes.Camera.ToString());
            nodeCameras.Tag = TreeNodeTypes.Camera;

            TreeNode nodeImages = new TreeNode(TreeNodeTypes.Images.ToString());
            nodeImages.Tag = TreeNodeTypes.Images;

            TreeNode nodeAnimations = new TreeNode(TreeNodeTypes.Animations.ToString());
            nodeAnimations.Tag = TreeNodeTypes.Animations;

            this.treeView1.Nodes.Add(nodeObjects);
            this.treeView1.Nodes.Add(nodeLights);
            this.treeView1.Nodes.Add(nodeCameras);
            this.treeView1.Nodes.Add(nodeImages);
            this.treeView1.Nodes.Add(nodeAnimations);
        }

        private void AddItem(object obj, TreeNodeTypes typ)
        {
            //TreeNode node = new TreeNode(obj.ToString());
            //node.Tag = obj;
            //this.treeView1.Nodes.Add(node);

            TreeNodeTypes rootTyp = typ;
            if (typ == TreeNodeTypes.Cubes || typ == TreeNodeTypes.Spheres ||
                typ == TreeNodeTypes.Planes || typ == TreeNodeTypes.Cylinders)
                rootTyp = TreeNodeTypes.Objects;

            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Tag == null)
                    continue;

                if ((TreeNodeTypes)node.Tag == rootTyp && rootTyp == TreeNodeTypes.Objects)
                {
                    foreach (TreeNode node2 in node.Nodes)
                    {
                        if (node2.Tag == null)
                            continue;

                        if ((TreeNodeTypes)node2.Tag == typ)
                        {
                            DrawingObject drobj = (DrawingObject)obj;
                            //DefaultShape ds = (DefaultShape)obj;
                            DefaultShape ds = (DefaultShape)drobj.ModelObject;
                            TreeNode novyNode = new TreeNode(ds.ToString());
                            novyNode.Tag = obj;
                            if (ds.IsActive)
                                novyNode.Checked = true;

                            node2.Nodes.Add(novyNode);
                        }
                    }
                }

                else if((TreeNodeTypes)node.Tag == rootTyp && rootTyp == TreeNodeTypes.Lights)
                {
                    DrawingLight drLight = (DrawingLight)obj;
                    //Light light = (Light)obj;
                    Light light = (Light)drLight.ModelObject;
                    TreeNode novyNode = new TreeNode(obj.ToString());
                    novyNode.Tag = obj;
                    if (light.IsActive)
                        novyNode.Checked = true;
                    node.Nodes.Add(novyNode);
                }
                else if ((TreeNodeTypes)node.Tag == rootTyp && rootTyp == TreeNodeTypes.Camera)
                {
                    DrawingCamera drCam = (DrawingCamera)obj;
                    //Camera cam = (Camera)obj;
                    Camera cam = (Camera)drCam.ModelObject;
                    TreeNode novyNode = new TreeNode(cam.ToString());
                    novyNode.Tag = drCam;
                    novyNode.Checked = true;
                    node.Checked = true;
                    node.Nodes.Add(novyNode);
                }
                else if ((TreeNodeTypes)node.Tag == rootTyp && rootTyp == TreeNodeTypes.Images)
                {
                    RayImage img = (RayImage)obj;
                    TreeNode novyNode = new TreeNode(img.ToString());
                    novyNode.Tag = img;
                    novyNode.Checked = true;
                    node.Checked = true;
                    node.Nodes.Add(novyNode);
                }
                else if ((TreeNodeTypes)node.Tag == rootTyp && rootTyp == TreeNodeTypes.Animations)
                {
                    DrawingAnimation drAnim = (DrawingAnimation)obj;
                    TreeNode novyNode = new TreeNode(drAnim.ToString());
                    novyNode.Tag = drAnim;
                    novyNode.Checked = drAnim.ShowAnimation;
                    node.Checked = true;
                    node.Nodes.Add(novyNode);
                }
                else if ((TreeNodeTypes)node.Tag == rootTyp)
                {
                    TreeNode novyNode = new TreeNode(obj.ToString());
                    novyNode.Tag = obj;
                    novyNode.Checked = true;
                    node.Checked = true;
                    node.Nodes.Add(novyNode);
                }
            }
        }

        /// <summary>
        /// Vsechna data aktualizuje
        /// </summary>
        public void UpdateRecords()
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                UpdateRecords(node);
            }
            //this.treeView1.Focus();

            WndProperties prop = GetWndProperties();
            prop.ShowObject(treeView1.SelectedNode.Tag);

            this.Update();
        }

        private void UpdateRecords(TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                childNode.Text = childNode.Tag.ToString();
                UpdateRecords(childNode);
            }
        }
        /// <summary>
        /// Prida do seznamu objekt ze sveta Raytraceru: 
        /// koule, rovina, valec, krychle, svetlo, kamera, image, animation
        /// </summary>
        /// <param name="obj"></param>
        //public void AddItem(DefaultShape obj)
        //{
        //    if (obj.GetType() == typeof(RayTracerLib.Sphere))
        //    {
        //        this.AddItem(obj, TreeNodeTypes.Spheres);
        //    }
        //    else if (obj.GetType() == typeof(RayTracerLib.Plane))
        //    {
        //        this.AddItem(obj, TreeNodeTypes.Planes);
        //    }
        //    else if (obj.GetType() == typeof(RayTracerLib.Cube))
        //    {
        //        this.AddItem(obj, TreeNodeTypes.Cubes);
        //    }
        //    else if (obj.GetType() == typeof(RayTracerLib.Cylinder))
        //    {
        //        this.AddItem(obj, TreeNodeTypes.Cylinders);
        //    }
        //}

        /// <summary>
        /// Prida do seznamu objekt ze sveta Raytraceru: 
        /// koule, rovina, valec, krychle, svetlo, kamera, image, animation
        /// </summary>
        /// <param name="obj"></param>
        public void AddItem(DrawingObject drawObj)
        {
            if (drawObj.GetType() == typeof(DrawingSphere))
            {
                this.AddItem(drawObj, TreeNodeTypes.Spheres);
            }
            else if (drawObj.GetType() == typeof(DrawingPlane))
            {
                this.AddItem(drawObj, TreeNodeTypes.Planes);
            }
            else if (drawObj.GetType() == typeof(DrawingCube))
            {
                this.AddItem(drawObj, TreeNodeTypes.Cubes);
            }
            else if (drawObj.GetType() == typeof(DrawingCylinder))
            {
                this.AddItem(drawObj, TreeNodeTypes.Cylinders);
            }
            else if (drawObj.GetType() == typeof(DrawingAnimation))
            {
                this.AddItem(drawObj, TreeNodeTypes.Animations);
            }
        }

        public void AddItem(DrawingLight light)
        {
            this.AddItem(light, TreeNodeTypes.Lights);
        }
        public void AddItem(DrawingCamera cam)
        {
            this.AddItem(cam, TreeNodeTypes.Camera);
        }
        public void AddItem(RayImage img)
        {
            this.AddItem(img, TreeNodeTypes.Images);
        }

        private void OnAfterSelect(object sender, TreeViewEventArgs e)
        {

            //this.AddItem(new RayTracerLib.Sphere(new Vektor(), 1));
            TreeNode node = e.Node;
            if (node.Tag == null)
                return;

            // kdyz se jedna o konkretni instanci objektu v seznamu - neni to obecna skupina
            if (node.Tag.GetType() != typeof(TreeNodeTypes))
            {
                ParentEditor form = (ParentEditor)this.ParentForm;
                form._WndProperties.ShowObject(node.Tag);
                //if (node.Tag is DefaultShape)
                // zviditelni vykreslovany objekt, ktery byl vybran ze seznamu objektu
                if (node.Tag is DrawingObject)
                {
                    //DefaultShape ds = (DefaultShape)node.Tag;
                    DrawingObject dro = (DrawingObject)node.Tag;
                    //if (dro.ModelObject is DefaultShape)
                    //DefaultShape ds = (DefaultShape)dro.ModelObject;
                    form._WndBoard.SetObjectSelected(dro);
                    //node.Checked = ds.IsActive;
                }
            }
            else
            {
                TreeNodeTypes typ = (TreeNodeTypes)node.Tag;
                ParentEditor form = (ParentEditor)this.ParentForm;
                form._WndProperties.ShowObject(node.Tag);
            }

        }

        private void ShowNode(object shape, TreeNode rootNode)
        {
            if (rootNode.Nodes == null)
                return;

            foreach (TreeNode node in rootNode.Nodes)
            {
                // zjisteni dedicneho typu: zda-li je node.Tag zdedeny typ od DefaultShape

                if (node.Tag is DrawingLight)
                {
                    if (node.Tag == shape)
                    {
                        treeView1.SelectedNode = node;
                        this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        this.OnClicked(this, new EventArgs());
                        this.onMouseDown(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        this.treeView1.Focus();
                        this.treeView1.HideSelection = false;
                        this.OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        this.Update();
                    }
                }
                else if (node.Tag is DrawingCamera)
                {
                    if (node.Tag == shape)
                    {
                        treeView1.SelectedNode = node;
                        this.treeView1.Focus();
                        this.treeView1.HideSelection = false;
                    }
                }
                else if (node.Tag is DrawingDefaultShape)
                {
                    if (node.Tag == shape)
                    {
                        treeView1.SelectedNode = node;
                        node.Text = node.Tag.ToString();
                        this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        this.OnClicked(this, new EventArgs());
                        this.onMouseDown(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        this.treeView1.Focus();
                        this.treeView1.HideSelection = false;
                        this.OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        //this.OnGotFocus(new EventArgs());
                        //this.Activate();
                        //this.Focus();
                        this.Update();
                        //this.Validate();
                        //this.Refresh();
                    }
                }
                else if (node.Tag is DrawingAnimation)
                {
                    if (node.Tag == shape)
                    {
                        treeView1.SelectedNode = node;
                        node.Text = node.Tag.ToString();
                        this.treeView1.Focus();
                        this.treeView1.HideSelection = false;
                    }
                }
                else if (node.Tag is RayImage)
                {
                    if (node.Tag == shape)
                    {
                        treeView1.SelectedNode = node;
                        node.Text = node.Tag.ToString();
                        this.treeView1.Focus();
                        this.treeView1.HideSelection = false;
                    }
                }
                else
                {
                    ShowNode(shape, node);
                }
            }
        }
        /// <summary>
        /// najde a vybere dany objekt v seznamu - ve strome objektu
        /// prochazi uzly stromu sceny a porovnava, jestli se shoduji se zadanym, ktery chceme zobrazit
        /// </summary>
        /// <param name="shape">bud: DefaultShape, Light</param>
        public void ShowNode(object shape)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (((TreeNodeTypes)node.Tag == TreeNodeTypes.Objects) && (shape is DrawingObject))
                {
                    ShowNode(shape, node);
                }
                else if (( (TreeNodeTypes)node.Tag == TreeNodeTypes.Lights ) && ( shape is DrawingLight ))
                {
                    ShowNode(shape, node);
                }
                else if (((TreeNodeTypes)node.Tag == TreeNodeTypes.Camera) && (shape is DrawingCamera))
                {
                    ShowNode(shape, node);
                }
                else if (((TreeNodeTypes)node.Tag == TreeNodeTypes.Images) && (shape is RayImage))
                {
                    ShowNode(shape, node);
                }
                else if (((TreeNodeTypes)node.Tag == TreeNodeTypes.Animations) && (shape is DrawingAnimation))
                {
                    ShowNode(shape, node);
                }
            }
        }

        private void OnClicked(object sender, EventArgs e)
        {

        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            int  a = 1;
        }

        
        public void CollapseAll()
        {
            this.treeView1.CollapseAll();
            this.treeView1.Nodes[0].Collapse();
            //this.treeView1.Nodes[0].Collapse(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            SetChildNodes(treeView1.Nodes[0]);

        }

        private void AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Tag is DrawingDefaultShape)
            {
                DrawingDefaultShape dds = (DrawingDefaultShape)e.Node.Tag;
                DefaultShape ds = (DefaultShape)dds.ModelObject;
                ds.IsActive = e.Node.Checked;
                ParentEditor pe = (ParentEditor)this.ParentForm;
                pe._WndBoard.Redraw();
                this.Invalidate();
                this.Update();
            }
            else if (e.Node.Tag is DrawingLight)
            {
                DrawingLight dl = (DrawingLight)e.Node.Tag;
                Light l = (Light)dl.ModelObject;
                l.IsActive = e.Node.Checked;
                ParentEditor pe = (ParentEditor)this.ParentForm;
                pe._WndBoard.Redraw();
                this.Invalidate();
                this.Update();
            }
            else if (e.Node.Tag is DrawingAnimation)
            {
                DrawingAnimation drAnim = (DrawingAnimation)e.Node.Tag;
                drAnim.ShowAnimation = e.Node.Checked;
            }
            else
            {
                SetChildNodes(e.Node);
            }

        }

        private void SetChildNodes(TreeNode root)
        {
            foreach (TreeNode node in root.Nodes)
            {
                node.Checked = root.Checked;
                SetChildNodes(node);
            }
        }
        private void NodeMouseDblClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {

            if (e.Node.Tag is DrawingCamera)
            {
                e.Cancel = true;
            }

            // osetreni, aby kamera byla porad zaskrknuta v seznamu
            if (e.Node.Tag is TreeNodeTypes && 
            (TreeNodeTypes)e.Node.Tag == TreeNodeTypes.Camera && 
            e.Node.Checked == true)
                e.Cancel = true;

            
            //if (e.Node.Tag is DrawingObject)
            //{
            //    DrawingObject dro = (DrawingObject)e.Node.Tag;
            //    if (dro.ModelObject is DefaultShape)
            //    {
            //        DefaultShape ds = (DefaultShape)dro.ModelObject;
            //        if (e.Node.Checked != ds.IsActive)
            //            e.Node.Checked = ds.IsActive;
            //        ParentEditor pe = (ParentEditor)this.ParentForm;
            //        pe._wndBoard.Redraw();
            //        this.Invalidate();
            //        this.Update();
            //    }
            //}
        }

        private WndBoard GetWndBoard()
        {
            ParentEditor pf = (ParentEditor)this.ParentForm;
            return pf._WndBoard;
        }

        private WndProperties GetWndProperties()
        {
            ParentEditor form = (ParentEditor)this.ParentForm;
            return form._WndProperties;
        }

        private void OnRemoveObjectFromScene(object sender, EventArgs e)
        {
            // kdyz je to obecny typ, nemazeme nic
            if (treeView1.SelectedNode.Tag is TreeNodeTypes || treeView1.SelectedNode.Tag is DrawingCamera)
                return;

            WndBoard wndBoard = GetWndBoard();
            wndBoard.RemoveRaytrObject(treeView1.SelectedNode.Tag);
            treeView1.Nodes.Remove(treeView1.SelectedNode);

            WndProperties wndProp = GetWndProperties();
            wndProp.ShowDefault();
        }

        private void OnAddSphere(object sender, EventArgs e)
        {
            WndBoard wndBoard = GetWndBoard();
            wndBoard.AddRaytrObject(new Sphere(new Vektor(), 1));
        }

        private void OnAddPlane(object sender, EventArgs e)
        {
            WndBoard wndBoard = GetWndBoard();
            wndBoard.AddRaytrObject(new Plane(new Vektor(1, 0, 0), 2));
        }

        private void onAddCube(object sender, EventArgs e)
        {
            WndBoard wndBoard = GetWndBoard();
            wndBoard.AddRaytrObject(new Cube(new Vektor(), new Vektor(1, 0, 0), 1));
        }

        private void onAddCylinder(object sender, EventArgs e)
        {
            WndBoard wndBoard = GetWndBoard();
            wndBoard.AddRaytrObject(new Cylinder(new Vektor(), new Vektor(1, 0, 0), 1, 5));
        }

        private void onAddLight(object sender, EventArgs e)
        {
            WndBoard wndBoard = GetWndBoard();
            wndBoard.AddRaytrObject(new Light());
        }

        private void onAddImage(object sender, EventArgs e)
        {
            RayImage img = new RayImage(1, new Colour(1, 0, 0, 0), false);
            this.AddItem(img, TreeNodeTypes.Images);
            this.ShowNode(img);
        }

        private void onAddAnimation(object sender, EventArgs e)
        {
            WndBoard wndBoard = GetWndBoard();
            wndBoard.AddAnimation(new DrawingAnimation());
        }


    }
}
