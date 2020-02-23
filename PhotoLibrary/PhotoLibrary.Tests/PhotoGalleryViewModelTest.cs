using Moq;
using PhotoLibrary.Helpers;
using PhotoLibrary.ViewModel;
using PhotoLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PhotoLibrary.Tests {
    [TestClass]
    public class PhotoGalleryViewModelTest {
        private Mock<IFileHelper> fileHelper;
        private string dummyLocation = "DummyLocation";

        private PhotoGalleryViewModel GetViewModel() {
            return new PhotoGalleryViewModel(this.fileHelper.Object, dummyLocation);
        }

        [TestInitialize]
        public void SetUp() {
            fileHelper = new Mock<IFileHelper>();
        }


        [TestMethod]
        public void AllPhotoIsNotNullWhenLocationHasPhotos() {

            AsyncObservableCollection<Photo> photos = null;
            fileHelper.Setup(x => x.GetImagesInFolder(It.IsAny<string>())).Returns(new List<Photo> { new Photo(dummyLocation) });

            var viewModel = GetViewModel();
            photos = viewModel.AllPhotos;

            Assert.IsNotNull(photos);
        }

        [TestMethod]
        public void AllPhotoIsNullWhenLocationHasNoPhotos() {

            AsyncObservableCollection<Photo> photos = null;
            var expectedPhotos = fileHelper.Object.GetImagesInFolder(dummyLocation).ToObservableCollection();

            var viewModel = GetViewModel();
            photos = viewModel.AllPhotos;

            Assert.AreEqual(expectedPhotos, photos);

        }
    }
}
