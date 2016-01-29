PeopleManager.module("PeopleApp.List", function (List, PeopleManager, Backbone, Marionette, $, _) {
  List.Controller = {
    listPeople: function () {
     
      var loadingView = new PeopleManager.Common.Loading.SpinnerView();
      PeopleManager.regions.main.show(loadingView);

      var fetchingPeople = PeopleManager.request("person:entities");

      var peopleListLayout;

      $.when(fetchingPeople).done(function (people) {


        var peopleListView = new List.PeopleList({
          collection: people
        });


        peopleListLayout = new List.Layout();

        peopleListLayout.on("show", function () {
          peopleListLayout.PeopleRegion.show(peopleListView);
        });

        peopleListView.on("childview:person:edit", function (childView, model) {
          PeopleManager.trigger("person:edit", model);
        });

        PeopleManager.regions.main.show(peopleListLayout);
      });
    }
  }
});