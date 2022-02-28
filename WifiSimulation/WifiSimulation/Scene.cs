using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WifiSimulation
{
    class Scene
    {
        LogTransformation logTransformation;
        public List<GraphicModel> models;
        int ground = 400;

        public Scene()
        {
            this.logTransformation = new LogTransformation();
            this.models = new List<GraphicModel>();
        }

        public Scene(Scene scene)
        {
            this.logTransformation = new LogTransformation(scene.logTransformation);

            this.models = new List<GraphicModel>(scene.models.Count);
            for (int i = 0; i < scene.models.Count; i++)
                this.models.Add(new GraphicModel(scene.models[i], this.logTransformation));
        }

        public void Transform(LogTransformation logTransformation)
        {
            foreach (GraphicModel graphicModel in models)
                graphicModel.Transform(logTransformation);
            this.logTransformation.Add(logTransformation);
        }

        public void Transform(WritingTransformation writingTransformation)
        {
            foreach (GraphicModel graphicModel in models)
                graphicModel.Transform(writingTransformation);
            this.logTransformation.Add(writingTransformation);
        }

        public void CreateCubeOnGround(Color color, int xCent, int dx, int zCent, int dz, int height, int i = -1)
        {
            GraphicModel graphicModel = new GraphicModel(logTransformation);

            // передняя грань
            graphicModel.AddVertex(new Point3D(xCent - dx, ground, zCent + dz)); // левая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground, zCent + dz)); // правая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground - height, zCent + dz)); // правая верхняя вершина
            graphicModel.AddVertex(new Point3D(xCent - dx, ground - height, zCent + dz)); // левая верхняя вершина

            // задняя грань
            graphicModel.AddVertex(new Point3D(xCent - dx, ground, zCent - dz)); // левая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground, zCent - dz)); // правая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground - height, zCent - dz)); // правая верхняя вершина
            graphicModel.AddVertex(new Point3D(xCent - dx, ground - height, zCent - dz)); // левая верхняя вершина

            graphicModel.CreatePolygon(color, false, 3, 2, 6, 7); // верхняя грань
            graphicModel.CreatePolygon(color, false, 0, 1, 2, 3); // передняя грань
            graphicModel.CreatePolygon(color, false, 0, 3, 7, 4); // левая грань
            graphicModel.CreatePolygon(color, false, 4, 7, 6, 5); // задняя грань
            graphicModel.CreatePolygon(color, false, 1, 5, 6, 2); // правая грань
            graphicModel.CreatePolygon(color, false, 0, 4, 5, 1); // нижняя грань

            if (i < 0)
                models.Add(graphicModel);
            else
                models.Insert(i, graphicModel);
        }

        public void CreateCube(Color color, int xCent, int dx, int yCent, int dy, int zCent, int dz, int i = -1)
        {
            GraphicModel graphicModel = new GraphicModel(logTransformation);

            // передняя грань
            graphicModel.AddVertex(new Point3D(xCent - dx, yCent + dy, zCent + dz)); // левая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, yCent + dy, zCent + dz)); // правая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, yCent - dy, zCent + dz)); // правая верхняя вершина
            graphicModel.AddVertex(new Point3D(xCent - dx, yCent - dy, zCent + dz)); // левая верхняя вершина

            // задняя грань
            graphicModel.AddVertex(new Point3D(xCent - dx, yCent + dy, zCent - dz)); // левая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, yCent + dy, zCent - dz)); // правая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, yCent - dy, zCent - dz)); // правая верхняя вершина
            graphicModel.AddVertex(new Point3D(xCent - dx, yCent - dy, zCent - dz)); // левая верхняя вершина

            graphicModel.CreatePolygon(color, false, 3, 2, 6, 7); // верхняя грань
            graphicModel.CreatePolygon(color, false, 0, 1, 2, 3); // передняя грань
            graphicModel.CreatePolygon(color, false, 0, 3, 7, 4); // левая грань
            graphicModel.CreatePolygon(color, false, 4, 7, 6, 5); // задняя грань
            graphicModel.CreatePolygon(color, false, 1, 5, 6, 2); // правая грань
            graphicModel.CreatePolygon(color, false, 0, 4, 5, 1); // нижняя грань

            if (i < 0)
                models.Add(graphicModel);
            else
                models.Insert(i, graphicModel);
        }

        public void CreateSpecialSlice(MapColor mapColor, int xCent, int dx, int zCent, int dz, int y, int i = -1)
        {
            GraphicModel graphicModel = new GraphicModel(logTransformation);

            graphicModel.AddVertex(new Point3D(xCent - dx, y, zCent + dz));
            graphicModel.AddVertex(new Point3D(xCent + dx, y, zCent + dz));
            graphicModel.AddVertex(new Point3D(xCent + dx, y, zCent - dz));
            graphicModel.AddVertex(new Point3D(xCent - dx, y, zCent - dz));

            graphicModel.CreatePolygon(mapColor, false, 0, 1, 2, 3);

            if (i < 0)
                models.Add(graphicModel);
            else
                models.Insert(i, graphicModel);
        }

        public void CreateGround(int xCent, int dx, int zCent, int dz, int y, int depth, int i = -1)
        {
            GraphicModel graphicModel = new GraphicModel(logTransformation);
            this.ground = y;

            // передняя грань
            graphicModel.AddVertex(new Point3D(xCent - dx, ground + depth, zCent + dz)); // левая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground + depth, zCent + dz)); // правая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground, zCent + dz)); // правая верхняя вершина
            graphicModel.AddVertex(new Point3D(xCent - dx, ground, zCent + dz)); // левая верхняя вершина

            // задняя грань
            graphicModel.AddVertex(new Point3D(xCent - dx, ground + depth, zCent - dz)); // левая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground + depth, zCent - dz)); // правая нижняя вершина
            graphicModel.AddVertex(new Point3D(xCent + dx, ground, zCent - dz)); // правая верхняя вершина
            graphicModel.AddVertex(new Point3D(xCent - dx, ground, zCent - dz)); // левая верхняя вершина

            graphicModel.CreatePolygon(Color.Green, true, 3, 2, 6, 7); // верхняя грань
            graphicModel.CreatePolygon(Color.Green, true, 0, 1, 2, 3); // передняя грань
            graphicModel.CreatePolygon(Color.Green, true, 0, 3, 7, 4); // левая грань
            graphicModel.CreatePolygon(Color.Green, true, 4, 7, 6, 5); // задняя грань
            graphicModel.CreatePolygon(Color.Green, true, 1, 5, 6, 2); // правая грань
            graphicModel.CreatePolygon(Color.Green, true, 0, 4, 5, 1); // нижняя грань

            if (i < 0)
                models.Add(graphicModel);
            else
                models.Insert(i, graphicModel);
        }

        public int Count()
        {
            return models.Count;
        }

        public void Remove(int i)
        {
            models.RemoveAt(i);
        }
    }
}
