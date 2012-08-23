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
                            TreeNode novyNode = new TreeNode(obj.ToString());
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
                    novyNode.Tag = obj;
                    novyNode.Checked = true;
                    node.Checked = true;
                    node.Nodes.Add(novyNode);
                }
                else if ((TreeNodeTypes)node.Tag == rootTyp)
                {
                    TreeNode novyNode = new TreeNode(obj.ToString());
                    novyNode.Tag = obj;
                    node.Nodes.Add(novyNode);
                }
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
        }

        //public void AddItem(Light light)
        //{
        //    this.AddItem(light, TreeNodeTypes.Lights);
        //}
        //public void AddItem(Camera cam)
        //{
        //    this.AddItem(cam, TreeNodeTypes.Camera);
        //}
        //public void AddItem(RayImage img)
        //{
        //    this.AddItem(img, TreeNodeTypes.Images);
        //}
        //public void AddItem(Animation obj)
        //{
        //}

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
        public void AddItem(Animation obj)
        {
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
                form._wndProperties.ShowObject(node.Tag);
                //if (node.Tag is DefaultShape)
                // zviditelni vykreslovany objekt, ktery byl vybran ze seznamu objektu
                if (node.Tag is DrawingObject)
                {
                    //DefaultShape ds = (DefaultShape)node.Tag;
                    DrawingObject dro = (DrawingObject)node.Tag;
                    //if (dro.ModelObject is DefaultShape)
                    //DefaultShape ds = (DefaultShape)dro.ModelObject;
                    form._wndBoard.SetObjectSelected(dro);
                    //node.Checked = ds.IsActive;
                }
            }
            else
            {
                TreeNodeTypes typ = (TreeNodeTypes)node.Tag;
                ParentEditor form = (ParentEditor)this.ParentForm;
                form._wndProperties.ShowObject(node.Tag);
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
                else if (node.Tag is DrawingObject)
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
                        //this.OnGotFocus(new EventArgs());
                        //this.Activate();
                        //this.Focus();
                        this.Update();
                        //this.Validate();
                        //this.Refresh();
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
                pe._wndBoard.Redraw();
                this.Invalidate();
                this.Update();
            }
            else if (e.Node.Tag is DrawingLight)
            {
                DrawingLight dl = (DrawingLight)e.Node.Tag;
                Light l = (Light)dl.ModelObject;
                l.IsActive = e.Node.Checked;
                ParentEditor pe = (ParentEditor)this.ParentForm;
                pe._wndBoard.Redraw();
                this.Invalidate();
                this.Update();
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


    }
}