using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Selery.Model.Entity.Registration;
using Selery.Web.Api.Models.Registration.Interface;
using Selery.Web.Api.Models.Workout.Interface;
using Selery.Web.Api.Models.Nutrition.Interface;
using Selery.Web.Api.Models.B2B.Interface;
using Selery.Web.Api.Models.Registration.Repository;
using Selery.Web.Api.Models.Workout.Repository;
using Selery.Web.Api.Models.Nutrition.Repository;
using Selery.Web.Api.Models.B2B.Repository;
using Selery.Web.Api.Controllers.Registration;
using Selery.Web.Api.Controllers.Workout;
using Selery.Web.Api.Controllers.Nutrition;
using Selery.Web.Api.Controllers.B2B;

namespace Selery.Web.Api.App_Code
{
    public class SeleryContainer : IDependencyResolver 
    {        
        static readonly IRegistration registrationRepository= new RegistrationRepository();
        static readonly IWorkout workoutRepository = new WorkoutRepository();
        static readonly INutrition nutritionRepository = new NutritionRepository();
        static readonly IB2B b2bRepository = new B2BRepository();

        public IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'. 
            return this;
        }

        public object GetService(Type serviceType)
        {

            if (serviceType == typeof(RegistrationController))
            {
                return new RegistrationController(registrationRepository);
            }
            if (serviceType == typeof(WorkoutController))
            {
                return new WorkoutController(workoutRepository);
            }
            if (serviceType == typeof(NutritionController))
            {
                return new NutritionController(nutritionRepository);
            }
            if (serviceType == typeof(B2BController))
            {
                return new B2BController(b2bRepository);
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op. 
        } 


    }

}
