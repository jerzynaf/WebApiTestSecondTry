PeopleManager.module("PeopleApp.Edit", function (Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.Controller = {
    editPerson: function (id) {
      var loadingView = new PeopleManager.Common.Loading.SpinnerView();
      PeopleManager.regions.main.show(loadingView);

      var fetchingContact = PeopleManager.request("person:entity", id);
      $.when(fetchingContact).done(function (person) {
        var view;



        if (person !== undefined) {
          view = new Edit.Form({
            model: person
          });

          view.on("form:submit", function (data) {
            var defer = $.Deferred();
            person.save(data, {
              success: function () {
                defer.resolve();
              }
            });
            var promise = defer.promise();
            $.when(promise).done(function () {
              PeopleManager.trigger("people:list");
            });
          });
          view.on("person:cancelEditing", function () {
            PeopleManager.trigger("people:list");
          });

          view.on("show", function () {
            var rawColours = person.get("colours");
            var coloursCollection = PeopleManager.request("colour:entities", rawColours);
            var coloursView = new Edit.Colours({
              collection: coloursCollection
            });
            view.favouriteColoursRegion.show(coloursView);
          });


        } else {
          view = new PeopleManager.PeopleApp.List.NoPeople();
        }

        PeopleManager.regions.main.show(view);
      });
    }
  };
});