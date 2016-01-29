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

        peopleListView.on("childview:person:edit", function (childView, args) {
          alert("Not implemented yet");
          //var model = args.model;
          //var view = new ContactManager.ContactsApp.Edit.Contact({
          //  model: model
          //});

          //view.on("form:submit", function (data) {
          //  if (model.save(data)) {
          //    childView.render();
          //    view.trigger("dialog:close");
          //    childView.flash("success");
          //  }
          //  else {
          //    view.triggerMethod("form:data:invalid", model.validationError);
          //  }
          //});

          //ContactManager.regions.dialog.show(view);
        });

        PeopleManager.regions.main.show(peopleListLayout);
      });
    }
  }
});