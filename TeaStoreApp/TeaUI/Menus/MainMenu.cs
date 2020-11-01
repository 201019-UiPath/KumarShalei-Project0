using TeaDB.Entities;
using TeaDB.IMappers;
using TeaDB;
using TeaLib;

namespace TeaUI.Menus
{
    public class MainMenu
    {
        private string userInput;
        private LocationMenu locationMenu;        
        private BasketMenu basketMenu;
        public MainMenu(TeaContext context, IMapper mapper){
            //this.locationMenu = new LocationMenu(new DBRepo(context,mapper), new OrderPlaced());
            //this.mapper = mapper;
        }
    }
}