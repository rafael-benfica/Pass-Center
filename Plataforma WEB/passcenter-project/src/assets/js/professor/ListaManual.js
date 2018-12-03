
export default {
    name: "ListaManual2",
    data() {
        return {
            datapicker: "",
            timepicker: ""
        }
    },
    mounted: function () {
        $(document).ready(function () {
            $('.datepicker').datepicker();
        });
        $(document).ready(function () {
            $('.timepicker').timepicker();
        });
    }

   
}


