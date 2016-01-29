PeopleManager.module("Common.Loading", function (Loading, PeopleManager, Backbone, Marionette, $, _) {
  Loading.SpinnerView = Marionette.ItemView.extend({
    template: "#Loading-view",
    onShow: function () {
      new Spinner().spin($('#spinner')[0]);
    }
  });
});