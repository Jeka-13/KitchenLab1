using Kitchen.Helpers.Enums;

namespace Kitchen.Models
{
    public class KitchenFood : Food
    {
        public KitchenFoodState State;

        public KitchenFood(Food food)
        {
            this.Name = food.Name;
            this.PreparitionTime = food.PreparitionTime;
            this.CookingApparatus = food.CookingApparatus;
            this.Comlexity = food.Comlexity;
            State = KitchenFoodState.NotStarted;
        } 
    }
}
