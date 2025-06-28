# 🏞️Tailings-Management-System
*A GIS-based platform for environmental supervision and emergency analysis of tailings ponds*

---

## 📘 项目简介 | Project Introduction
This system is designed for tailings pond safety. It integrates data management, risk grading, spatial analysis, and emergency assistance using open-source GIS and database technologies.

---

## 🚀 Core Features

### ✅ Tailings Pond Evaluation and Classification

- Automatic scoring based on pond capacity, dam height, service years, and downstream risk  
- Classification into Levels I–IV, following China’s supervision guideline  
- Configurable scoring parameters and visualized color mapping  

### 🗺️ GIS Display and Analysis

- Loads tailings pond locations, administrative boundaries, rivers, and roads  
- Supports base map switching, zooming, layer control, and spatial positioning  

### 🌊 溃Dam Break Path and Submersion Analysis

- Calculates dam break paths based on failure points  
- Renders submerged areas and assesses affected zones  

### 🔍 Data Query and Maintenance

- Supports queries by ID, name, and location  
- Includes form editing, field explanations, and history tracking  

### 🚨 Emergency Response Assistance

- Displays emergency contacts and contingency plans  
- Supports rendering evacuation routes and emergency zones  

---

## 🛠️ Technology Stack

- **Frontend**: C# + WinForms, integrated with DotSpatial map control  
- **GIS Engine**: DotSpatial, a .NET-based open-source GIS framework  
- **Database**: MySQL to store pond metadata, grading parameters, and logs  
- **Analysis**: Custom C# modules for scoring, dam break simulation, and spatial matching  
- **Data Types**: DEM elevation data, vector layers, tabular inputs (Excel)  

---

## ✨ Project Highlights

- Unified spatial-attribute visualization and supervision logic  
- Supports DEM-based topographic calculation and impact mapping  
- Piloted by Shaanxi Environmental Investigation & Assessment Center  
- Modular design allows future integration with AI, IoT, or remote sensing  

