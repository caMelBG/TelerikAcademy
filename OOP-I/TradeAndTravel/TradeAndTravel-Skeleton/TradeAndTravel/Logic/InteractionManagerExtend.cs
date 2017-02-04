using System.Linq;

namespace TradeAndTravel
{
    public class InteractionManagerExtend : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(Person actor, string[] commandWords)
        {
            var newItemName = commandWords[3];
            if (commandWords[2] == "armor")
            {
                if (actor.ListInventory().Any(x => x is Iron))
                {
                    var newItem = new Armor(newItemName);
                    ownerByItem[newItem] = actor;
                    actor.AddToInventory(newItem);
                }
            }
            else if (commandWords[2] == "weapon")
            {
                if (actor.ListInventory().Any(x => x is Iron) &&
                    actor.ListInventory().Any(x => x is Wood))
                {
                    var newItem = new Weapon(newItemName);
                    ownerByItem[newItem] = actor;
                    actor.AddToInventory(newItem);
                }
            }
        }

        private void HandleGatherInteraction(Person actor, string[] commandWords)
        {
            var newItemName = commandWords[2];
            if (actor.Location is Mine)
            {
                foreach (var item in actor.ListInventory())
                {
                    if (item is Armor)
                    {
                        var newItem = new Iron(newItemName);
                        ownerByItem[newItem] = actor;
                        actor.AddToInventory(newItem);
                        break;
                    }
                }
            }
            else if (actor.Location is Forest)
            {
                foreach (var item in actor.ListInventory())
                {
                    if (item is Weapon)
                    {
                        var newItem = new Wood(newItemName);
                        ownerByItem[newItem] = actor;
                        actor.AddToInventory(newItem);
                        break;
                    }
                }
            }
        }


        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }
    }
}
