using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            //IOC Container

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBannerDal, EfBannerDal>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<IBrandService, BrandManager>();

            services.AddScoped<ICarDal, EfCarDal>();
            services.AddScoped<ICarService, CarManager>();

            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IUserSocialService, UserSocialManager>();
            services.AddScoped<IUserSocialDal, EfUserSocialDal>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<IReviewDal, EfReviewDal>();
            services.AddScoped<IReviewService, ReviewManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IProcessDal, EfProcessDal>();
            services.AddScoped<IProcessService, ProcessManager>();

            services.AddScoped<IDashboardDal, EfDashboardDal>();
            services.AddScoped<IDashboardService, DashboardManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

        }
    }
}
