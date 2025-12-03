**AI & Computer Vision Driven 2D Level Generation from Hand-Drawn Sketches**

This project transforms simple hand-drawn 2D map sketches into fully playable Unity levels using a combination of synthetic data generation, U-Net deep learning segmentation, and procedural prefab instantiation. The system takes a scanned sketch, interprets rooms and corridors, exports them as structured JSON coordinates, and reconstructs the level in Unity in real time.


**For a complete technical breakdown, methods, results, and visuals, see the full report: Artificial Intelligence and Computer Vision Driven 2D Level Generation from Hand Drawn Sketches.pdf.**

**Demo Video**



https://github.com/user-attachments/assets/0a715a80-6373-41c2-b364-2b53d0ff5279



**Overview**

This project builds an end-to-end pipeline that:

- Understands a hand-drawn map
- Segments walls and structural elements using a U-Net CNN
- Post-processes the mask and extracts wall-tile coordinates
- Outputs a clean JSON representation of the map
- Reconstructs a playable 2D level inside Unity using C#

The workflow allows any designer, even without technical experience, to simply draw a layout and get a functional game level in seconds.

**Features**

_AI & Vision_

- Synthetic dataset generation (1,000+ procedurally generated maps)
- U-Net segmentation with Weighted BCE + Dice loss
- Extensive augmentations (blur, contrast, elastic deformation, line jitter)
- Achieves >90% IoU on hand-drawn test maps
- Robust corridor reconstruction (even thin structures)

_Level Generation_

- Pixel-perfect JSON export of wall coordinates
- Real-time Unity reconstruction using prefab instantiation
- Supports thousands of tiles with smooth performance (120+ FPS)
- Instant sketch → level workflow (< 500 ms end-to-end on GPU)

🚀 Pipeline
1. Synthetic Data Generation
Generates random layouts (rooms + MST-based corridors)
Adds augmentations to mimic hand-drawn sketches
2. Deep Learning Segmentation
U-Net trained in PyTorch
Composite loss → better thin-structure detection
Achieved 0.92 IoU, 0.94 Precision, 0.90 Recall
3. Post-Processing
Otsu thresholding
Morphological closing
Pixel extraction into JSON array
4. Unity Level Instantiation
Reads JSON with MiniJSON
Instantiates 1×1 wall prefabs at grid coordinates
Produces a playable level with colliders, physics, and full navigation
📂 Unity Integration
Place your JSON map file into Resources/ and assign it to the MapLoader script:
public TextAsset mapFile;
public GameObject wallPrefab;
public float cellSize = 1f;
Run the scene → your level is instantly generated.

📊 Results Summary
IoU: 0.92
Precision: 0.94
Recall: 0.90
Corridor recovery: 88% for very thin structures
End-to-end speed: ~350 ms (including Unity load)
Maximum tiles instantiated: ~10,000 at 120+ FPS
More experimental details, diagrams, and figures are available in the full report.

⚠️ Limitations
Model expects orthogonal, rectilinear sketches
Curved / artistic drawings degrade segmentation
Strict JSON format required
Only supports 2D tile-based Unity levels

🔮 Future Improvements
Support for irregular / circular rooms
Smart preprocessing for variable pen thickness
Unity Editor plugin for drag-and-drop import
3D reconstruction using volumetric U-Nets
Interactive correction & reinforcement learning feedback loop

📜 Citation / Reference
If referencing this project, cite the provided report:
Artificial Intelligence and Computer Vision Driven 2D Level Generation from Hand Drawn Sketches.pdf

🤝 Authors
Baker Huseyin
Islah Haoues
