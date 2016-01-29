PeopleManager.module("PeopleApp.List", function (List, PeopleManager, Backbone, Marionette, $, _) {
  List.Layout = Marionette.LayoutView.extend({
    template: "#People-list-layout",
    regions: {
      PeopleRegion: "#People-region"
    }
  });

  List.Person = Marionette.ItemView.extend({
    tagName: "tr",
    template: "#Row-template",
    events: {
      "click a": "editPerson"
    },
    editPerson: function (e) {
      e.preventDefault();
      e.stopPropagation();
      this.trigger("person:edit", this.model.get("id"));
    }
  });
  List.NoPeople = Marionette.ItemView.extend({
    template: "#People-list-none",
    tagName: "tr",
    className: "alert"
  });

  List.PeopleList = Marionette.CompositeView.extend({
    template: "#People-List",
    childView: List.Person,
    childViewContainer: "tbody",
    emptyView: List.NoPeople,
    tagName: "table",
    className: "table table-hover"
  });







});