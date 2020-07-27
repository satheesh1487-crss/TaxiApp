using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DASetPrivilege
    {
       public List<GrandParentMenuhierarchy> GetMenuList(long roleid,TaxiAppzDBContext context)
        {
            var menugrandparentlist = context.TabMenuAccess.Include(g => g.Menu).Where( r => r.Roleid == roleid && r.Menu.ParentId == 0).ToList();
            if (menugrandparentlist != null && menugrandparentlist.Count != 0)
            {
                List<GrandParentMenuhierarchy> grandParentMenuhierarchies = new List<GrandParentMenuhierarchy>();
                foreach (var menuparent in menugrandparentlist)
                {
                    var menuparentlist = context.TabMenuAccess.Include(p => p.Menu).Where(r => r.Menu.ParentId == menuparent.Menuid).ToList();
                    List<ParentMenuhierarchy> parentMenuhierarchies = new List<ParentMenuhierarchy>();
                    if (menuparentlist != null && menuparentlist.Count != 0)
                    {

                        foreach (var menuchild in menuparentlist)
                        {

                            var menuchildlist = context.TabMenuAccess.Include(c => c.Menu).Where(r => r.Menu.ParentId == menuchild.Menuid).ToList();
                            List<ChildMenuhierarchy> childMenuhierarchies = new List<ChildMenuhierarchy>();
                            if (menuchildlist != null && menuchildlist.Count != 0)
                            {
                                //  List<ChildMenuhierarchy> childMenuhierarchies = new List<ChildMenuhierarchy>();
                                foreach (var child in menuchildlist)
                                {

                                    childMenuhierarchies.Add(new ChildMenuhierarchy()
                                    {
                                        ChildMenuname = child.Menu.Name,
                                        Menuid = child.Menu.Menuid,
                                        ViewState = child.Viewstatus
                                    });

                                }
                            }
                            parentMenuhierarchies.Add(new ParentMenuhierarchy()
                            {
                                ParentMenuname = menuchild.Menu.Name,
                                Menuid = menuchild.Menu.Menuid,
                                ViewState = menuchild.Viewstatus,
                                childMenuhierarchies = childMenuhierarchies
                            });
                        }

                    }
                    grandParentMenuhierarchies.Add(new GrandParentMenuhierarchy()
                    {
                        GrandParentMenuname = menuparent.Menu.Name,
                        Menuid = menuparent.Menu.Menuid,
                        ViewState = menuparent.Viewstatus,
                        parentMenuhierarchies = parentMenuhierarchies
                    });
                }
                return grandParentMenuhierarchies;
            }
            return null;
            //var menugrandparentlist = context.TabMenu.Where(t => t.ParentId == 0 && t.IsActive == true).ToList();
            //if (menugrandparentlist != null && menugrandparentlist.Count != 0)
            //{
            //    List<GrandParentMenuhierarchy> grandParentMenuhierarchies = new List<GrandParentMenuhierarchy>();
            //    foreach (var menuparent in menugrandparentlist)
            //    {
            //        var menuparentlist = context.TabMenu.Where(t => t.ParentId == menuparent.Menuid && t.IsActive == true).ToList();
            //        List<ParentMenuhierarchy> parentMenuhierarchies = new List<ParentMenuhierarchy>();
            //        if (menuparentlist != null && menuparentlist.Count != 0)
            //        {

            //            foreach (var menuchild in menuparentlist)
            //            {

            //                var menuchildlist = context.TabMenu.Where(t => t.ParentId == menuchild.Menuid && t.IsActive == true).ToList();
            //                List<ChildMenuhierarchy> childMenuhierarchies = new List<ChildMenuhierarchy>();
            //                if (menuchildlist != null && menuchildlist.Count != 0)
            //                {
            //                    //  List<ChildMenuhierarchy> childMenuhierarchies = new List<ChildMenuhierarchy>();
            //                    foreach (var child in menuchildlist)
            //                    {

            //                        childMenuhierarchies.Add(new ChildMenuhierarchy()
            //                        {
            //                            ChildMenuname = child.Name,
            //                            Menuid = child.Menuid,
            //                            IsActive = child.IsActive
            //                        });

            //                    }
            //                }
            //                parentMenuhierarchies.Add(new ParentMenuhierarchy()
            //                {
            //                    ParentMenuname = menuchild.Name,
            //                    Menuid = menuchild.Menuid,
            //                    IsActive = menuchild.IsActive,
            //                    childMenuhierarchies = childMenuhierarchies
            //                });
            //            }

            //        }
            //        grandParentMenuhierarchies.Add(new GrandParentMenuhierarchy()
            //        {
            //            GrandParentMenuname = menuparent.Name,
            //            Menuid = menuparent.Menuid,
            //            IsActive = menuparent.IsActive,
            //            parentMenuhierarchies = parentMenuhierarchies
            //        });
            //    }
            //    return grandParentMenuhierarchies;
            //}
            //return null;
        }
    }
}
