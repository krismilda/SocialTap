using System;
using System.Collections.ObjectModel;

namespace MyApp.ViewModels
{
    public class MyViewModel
    {
        /// <summary>
        /// All models; loaded from appropriate data source.
        /// </summary>
        public ObservableCollection<MyModel> AllModels { get; set; }

        /// <summary>
        /// Model pairs, used for two-column list items.
        /// </summary>
        public ObservableCollection<ModelPair> ModelPairs { get; set; }

        public MyViewModel()
        {
            AllModels = new ObservableCollection<MyModel>();
            ModelPairs = new ObservableCollection<ModelPair>();
            CreateModelPairs();
        }

        /// <summary>
        /// Creating model pairs from all available model instances.
        /// </summary>
        private void CreateModelPairs()
        {
            for (int i = 0; i < AllModels.Count; i += 2)
            {
                MyModel item1 = AllModels[i];
                MyModel item2 = i + 1 < AllModels.Count ? AllModels[i + 1] : null;

                ModelPairs.Add(new ModelPair(item1, item2));
            }
        }
    }

    ///
    /// It's not necessary to use Tuple here
    /// Item1 used in left column; Item2 used in right column
    ///
    public class ModelPair : Tuple<MyModel, MyModel>
    {
        public ModelPair(MyModel item1, MyModel item2)
            : base(item1, item2 ?? CreateEmptyModel()) { }

        private static MyModel CreateEmptyModel()
        {
            return new MyModel
            {
                Id = -1 // -1 indicates that view should not be rendered
            };
        }
    }

    public class MyModel
    {
        public int Id { get; set; }
    }
}