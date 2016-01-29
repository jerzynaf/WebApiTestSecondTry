PeopleManager.module("PeopleApp.Edit", function (Edit, PeopleManager, Backbone, Marionette, $, _) {
  Edit.Form = Marionette.LayoutView.extend({
    template: "#Person-form",
    events: {
      "click button.js-saveChanges": "submitClicked",
      "click button.js-cancel": "cancelClicked",
      "click input.Is-authorised": "isAuthorisedClicked",
      "click input.Is-enabled": "isEnabledClicked"
    },
    ui: {
      isAuthorisedCheckbox: "#Is-authorised",
      isEnabledCheckbox: "#Is-enabled"
    },
    regions: {
      favouriteColoursRegion: "#Favourite-colours"
    },

    submitClicked: function (e) {
      e.preventDefault();
      var region = this.getRegion("favouriteColoursRegion");
      var colourView = region.currentView;
      var coloursCollection = colourView.collection;
      var data = Backbone.Syphon.serialize(this);
      data.colours = coloursCollection.toJSON();
      this.trigger("form:submit", data);
    },

    cancelClicked: function () {
      this.trigger("person:cancelEditing");
    },

    isAuthorisedClicked: function (e) {
      e.preventDefault();
      this.ui.isAuthorisedCheckbox.toggle();
    },

    isEnabledClicked: function (e) {
      e.preventDefault();
      this.ui.isEnabledCheckbox.toggle();
    }


  });

  Edit.Colour = Marionette.ItemView.extend({
    template: "#Colour",
    ui: {
      tickbox:"input"
    },
    events: {
      "click input":"itemClicked"
    },
    itemClicked:function(e) {
      this.model.set("isChecked", e.target.checked);
    }
  });

  Edit.Colours = Marionette.CollectionView.extend({
    childView: Edit.Colour
  });

  Edit.MissingPerson = Marionette.ItemView.extend({
    template: "#People-list-none"
  });
});