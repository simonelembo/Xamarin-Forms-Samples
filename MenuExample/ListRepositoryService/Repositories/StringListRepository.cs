using ListRepositoryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ListRepositoryService.Repositories
{
    public static class StringListRepository
    {
        private static List<ItemModel> itemsList = new List<ItemModel>();
        private static bool newItemAdded = false;
        private static ItemModel itemUpdated = new ItemModel();

        public static async Task<List<ItemModel>> GetAll(int numItems, string itemName)
        {
            if (itemsList == null || itemsList.Count != numItems)
            {
                await Task.Run(() => GenerateList(numItems, itemName));
                return itemsList;
            }
            else
            {
                return itemsList;
            }
        }

        private static void GenerateList(int numItems, string itemName)
        {
            Thread.Sleep(3000);
            itemsList = new List<ItemModel>();
            if (numItems > 0)
            {
                #region Calcola cifre decimali per number format
                int count = 1;
                for (int i = numItems; i > 1; i = i / 10)
                {
                    count++;
                }
                string numFormat = "D" + count;
                #endregion

                #region Genera lista
                string displayName;
                for (int i = 0; i < numItems; i++)
                {
                    displayName = itemName + i.ToString(numFormat);
                    itemsList.Add(new ItemModel() { Id = i, DisplayName = displayName });
                }
                #endregion
            }
            else
            {
                itemsList.Clear();
            }
        }

        public static async Task<List<ItemModel>> FilterList(string searchText)
        {
            if (!String.IsNullOrEmpty(searchText))
            {
                IEnumerable<ItemModel> resultQuery = await Task.Run(()=>ExecuteFilterQuery(searchText));
                return resultQuery.ToList<ItemModel>();
            }
            else
            {
                return itemsList;
            }
        }

        private static IEnumerable<ItemModel> ExecuteFilterQuery(string searchText)
        {
            Thread.Sleep(3000);
            itemsList = itemsList as List<ItemModel>;
            return itemsList.Where<ItemModel>(x => x.DisplayName.ToLower().Contains(searchText.ToLower()));
        }

        public static async Task<List<ItemModel>> AddNewItem(string newItemName)
        {
            newItemAdded = false;
            int newItemId = GenerateNewId();
            ItemModel item = new ItemModel() { Id = newItemId, DisplayName = newItemName };
            await Task.Run(() => AddNewItemToList(item));
            if (newItemAdded)
            {
                return itemsList;
            }
            else
            {
                return null;
            }
            
        }

        private static int GenerateNewId()
        {
            int maxId = itemsList.Max<ItemModel>(x => x.Id);
            return maxId + 1;
        }

        private static void AddNewItemToList(ItemModel newItem)
        {
            Thread.Sleep(3000);
            itemsList.Add(newItem);
            newItemAdded = true;
        }

        public static async Task<ItemModel> UpdateItem(ItemModel itemToUpdate)
        {
            itemUpdated = null;
            if (itemToUpdate != null)
            {
                await Task.Run(() => UpdateItemToList(itemToUpdate));
            }
            return itemUpdated;
        }

        private static void UpdateItemToList(ItemModel itemToUpdate)
        {
            Thread.Sleep(3000);
            itemsList.First<ItemModel>(x => x.Id == itemToUpdate.Id).DisplayName = itemToUpdate.DisplayName;
            itemUpdated = itemToUpdate;
        }
    }
}
