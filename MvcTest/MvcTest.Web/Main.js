var PeopleManager = new Marionette.Application();

PeopleManager.Person = Backbone.Model.extend({
    defaults: {
        firstName: "",
        lastName: ""
    }
});

PeopleManager.PeopleCollection = Backbone.Collection.extend({
    model: PeopleManager.Person
});

PeopleManager.PersonView = Marionette.ItemView.extend({
    template: "#person-template",
    events: {
        "click a": "alertFirstName"
    },
    alertFirstName: function () {
        alert(this.model.escape("firstName"));
    },
    tagName: "li"
});

PeopleManager.PeopleView = Marionette.CollectionView.extend({
    tagName: "ul",
    childView: PeopleManager.PersonView
});

PeopleManager.on("before:start", function () {
    var RegionContainer = Marionette.LayoutView.extend({
        el: "#app-container",
        regions: {
            main: "#main-region"
        }
    });

    PeopleManager.regions = new RegionContainer();
});

PeopleManager.on("start", function () {
    var people = new PeopleManager.PeopleCollection([
        {
            firstName: "Alice",
            lastName: "Arten"
        },
        {
            firstName: "James",
            lastName: "Johnson"
        }
    ]);

    var peopleListView = new PeopleManager.PeopleView({
        collection: people
    });

    PeopleManager.regions.main.show(peopleListView);
});

PeopleManager.start();
//27
//# sourceMappingURL=Main.js.map
