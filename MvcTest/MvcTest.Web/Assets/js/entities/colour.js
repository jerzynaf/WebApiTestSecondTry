PeopleManager.module("Entities", function (Entities, PeopleManager, Backbone, Marionette, $, _) {
  Entities.Colour = Backbone.Model.extend({
  });

  Entities.Colours = Backbone.Collection.extend({
   model:Entities.Colour
  });

  var API = {
    getColourEntities: function(rawColours) {
      var colours = new Entities.Colours(rawColours);
      return colours;
    }
  }
  PeopleManager.reqres.setHandler("colour:entities", function (rawColours) {
    return API.getColourEntities(rawColours);
  });

});