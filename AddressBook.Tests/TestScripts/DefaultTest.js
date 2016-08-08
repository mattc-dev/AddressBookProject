//write a simple service bus that will return items from the web api

describe("APIServiceTest", function () {
    var eventBus = _.extend({}, Backbone.Events);
    var service;
    var successString = FakeResponses.successString;
    var errorString = FakeResponses.errorString;

    // Test setup 
    beforeEach(function() {
        service = new ActivateDeviceService();
        service.eventBus = eventBus;
    });

    afterEach(function () {
        service = null;
    });

    // tests
    it("should return the correct model values", function() {
        expect();
    });

    it("should return a valid JSON file"), function () {
        expect()
    }

    it("should return an error"), function () {
        expect()
    }

    it("should return an invalid file"), function () {
        expect()
    }

    it("should return a 404 error"), function () {
        expect()
    }
})