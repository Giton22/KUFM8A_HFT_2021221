using KUFM8A_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KUFM8A_HFT_2021221.WpfClient
{
    internal class MainWindowViewModel:ObservableRecipient
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        #region Brand
        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set { 
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name = value.Name,
                        Region = value.Region,
                        Id = value.Id,
                    };
                }
                OnPropertyChanged();
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public RestCollection<Brand> Brands { get; set; }
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        #endregion
        #region Mobile
        private Mobile selectedMobile;
        
        public Mobile SelectedMobile
        {
            get { return selectedMobile; }
            set
            {
                if (value != null)
                {
                    selectedMobile = new Mobile()
                    {
                        Model = value.Model,
                        Price = value.Price,
                        Id = value.Id,
                    };
                }
                OnPropertyChanged();
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public RestCollection<Mobile> Mobiles { get; set; }
        public ICommand CreateMobileCommand { get; set; }
        public ICommand DeleteMobileCommand { get; set; }
        public ICommand UpdateMobileCommand { get; set; }
        #endregion
        #region CPU
        private Cpu selectedCpu;

        public Cpu SelectedCpu
        {
            get { return selectedCpu; }
            set
            {
                if (value != null)
                {
                    selectedCpu = new Cpu()
                    {
                        CPUName = value.CPUName,
                        Id = value.Id,
                    };
                }
                OnPropertyChanged();
                (DeleteCpuCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public RestCollection<Cpu> Cpus { get; set; }
        public ICommand CreateCpuCommand { get; set; }
        public ICommand DeleteCpuCommand { get; set; }
        public ICommand UpdateCpuCommand { get; set; }
        #endregion
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
            #region Brand
            Brands = new RestCollection<Brand>("http://localhost:23793/","brand","hub");
            CreateBrandCommand = new RelayCommand(() =>
             {
                 Brands.Add(new Brand()
                 {
                     Name = SelectedBrand.Name,
                     Region = SelectedBrand.Region,
                 });
             });

            UpdateBrandCommand = new RelayCommand(() =>
            {
                Brands.Update(SelectedBrand);
            });
            DeleteBrandCommand = new RelayCommand(() =>
            {
                Brands.Delete(SelectedBrand.Id);
            },
            () =>
            {
                return SelectedBrand != null;
            });
            selectedBrand=new Brand();
            #endregion
            #region Mobile
            Mobiles = new RestCollection<Mobile>("http://localhost:23793/", "mobile","hub");
            CreateMobileCommand = new RelayCommand(() =>
            {
                Mobiles.Add(new Mobile()
                {
                    Model=selectedMobile.Model,
                    Price=SelectedMobile.Price,
                });
            });

            UpdateMobileCommand = new RelayCommand(() =>
            {
                Mobiles.Update(SelectedMobile);
            });
            DeleteMobileCommand = new RelayCommand(() =>
            {
                Mobiles.Delete(SelectedMobile.Id);
            },
            () =>
            {
                return SelectedMobile != null;
            });
            selectedMobile = new Mobile();
                #endregion
            #region CPU
            Cpus = new RestCollection<Cpu>("http://localhost:23793/", "cpu", "hub");
            CreateCpuCommand = new RelayCommand(() =>
            {
                Cpus.Add(new Cpu()
                {
                    CPUName = selectedCpu.CPUName,
                });
            });

            UpdateCpuCommand = new RelayCommand(() =>
            {
                Cpus.Update(SelectedCpu);
            });
            DeleteCpuCommand = new RelayCommand(() =>
            {
                Cpus.Delete(SelectedCpu.Id);
            },
            () =>
            {
                return SelectedCpu != null;
            });
            selectedCpu = new Cpu();
                #endregion
            }
        }
    }
}