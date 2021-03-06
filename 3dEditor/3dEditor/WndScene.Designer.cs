﻿namespace _3dEditor
{
    partial class WndScene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cylinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(424, 288);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.BeforeCheck);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeMouseDblClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(424, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.bToolStripMenuItem,
            this.cubeToolStripMenuItem,
            this.cylinderToolStripMenuItem,
            this.coneToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.customObjectToolStripMenuItem,
            this.lightToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.animationToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::_3dEditor.Properties.Resources.add_1_icon16;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Add object to scene";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.sphere16;
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aToolStripMenuItem.Text = "Sphere";
            this.aToolStripMenuItem.ToolTipText = "Add sphere to scene";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.OnAddSphere);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.rectangle16;
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.bToolStripMenuItem.Text = "Plane";
            this.bToolStripMenuItem.ToolTipText = "Add plane to scene";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.OnAddPlane);
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.cube_icon24;
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.ToolTipText = "Add cube to scene";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.onAddCube);
            // 
            // cylinderToolStripMenuItem
            // 
            this.cylinderToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.cyl16;
            this.cylinderToolStripMenuItem.Name = "cylinderToolStripMenuItem";
            this.cylinderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.cylinderToolStripMenuItem.Text = "Cylinder";
            this.cylinderToolStripMenuItem.ToolTipText = "Add cylinder to scene";
            this.cylinderToolStripMenuItem.Click += new System.EventHandler(this.onAddCylinder);
            // 
            // coneToolStripMenuItem
            // 
            this.coneToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.cone_gray16;
            this.coneToolStripMenuItem.Name = "coneToolStripMenuItem";
            this.coneToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.coneToolStripMenuItem.Text = "Cone";
            this.coneToolStripMenuItem.Click += new System.EventHandler(this.onAddCone);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.TriangleMagenta16;
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.triangleToolStripMenuItem.Text = "Custom Plane";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.onAddCustomPlane);
            // 
            // customObjectToolStripMenuItem
            // 
            this.customObjectToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.wheel_32;
            this.customObjectToolStripMenuItem.Name = "customObjectToolStripMenuItem";
            this.customObjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.customObjectToolStripMenuItem.Text = "Custom Object";
            this.customObjectToolStripMenuItem.Click += new System.EventHandler(this.onAddCustomObject);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.sun16;
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.ToolTipText = "Add light to scene";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.onAddLight);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.drawing48;
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.onAddImage);
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.Image = global::_3dEditor.Properties.Resources.icon_camera16;
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.animationToolStripMenuItem.Text = "Animation";
            this.animationToolStripMenuItem.Click += new System.EventHandler(this.onAddAnimation);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::_3dEditor.Properties.Resources.remove_16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(30, 1, 0, 2);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton2.Text = "Remove from scene";
            this.toolStripButton2.Click += new System.EventHandler(this.OnRemoveObjectFromScene);
            // 
            // WndScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(424, 313);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WndScene";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Scene";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeforeClosing);
            this.Click += new System.EventHandler(this.OnClicked);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cylinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customObjectToolStripMenuItem;


    }
}