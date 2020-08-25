var app = new Vue({
    el: '#vueApp',
    data() {
        return {
            display: 'Hello Vue!',
            state_id: 0,
            cities: null,
            errored: false,
            loading: false,
            city_id: "",
        }
    },
    methods: {
        callApi() {

            axios
                .get('/Cities/CitiesByStateID/' + this.state_id)
                .then(response => {
                    this.cities = response.data
                })
                .catch(error => {
                    console.log(error)
                    this.errored = true
                })
                .finally(() => this.loading = false)
        },
        openCityModal(id) {
            this.city_id = id;
            console.log(this.city_id);
        },
    }
});


// Jquery goes here
$(function () {
    //Initialize Select2 Elements
    $('.select2').select2();
    //
    $('.select2').on("select2:select",
        function (e) {
            var state_id = e.params.data.id;
            app.state_id = state_id;
            app.callApi();
        });
    //Initialize Select2 Elements
    // $('#city_id').select2();
    //
    // $('#city_id').on("select2:select",
    //     function (e) {
    //         var city_id = e.params.data.id;
    //         // app.openCityModal(city_id);
            
    //     });

});
