<template>
    <div class="row area-exibicao">
        <form class="col s12 card data2">
            <div class="row topo">
                <div class="col s12 m12 l12">

                    <div class="input-field col s12 m12 l12">
                        <input id="date" type="text" class="datepicker" v-model="datepicker"> 
                        <label for="date">Data:</label>
                    </div>

                    <div class="input-field col s12 m12 l12">
                        <input id="time" type="text" class="timepicker" v-model="timepicker"> 
                        <label for="time">Horário:</label>
                    </div>

                    <div class="col s12 m12 l12 historico">
                       <router-link :to="{ name: 'ListaManual3' }" class=" waves-effect">
                             <button class="btn waves-effect waves-light" type="submit" name="action">Search
                                <i class="material-icons right">send</i>
                             </button>
                       </router-link>
                    </div>
                        
            </div> 
            </div>
        </form>
    </div>
</template>


<script src="./../../assets/js/professor/ListaManual.js"></script>
<style src="./../../assets/css/professor/MinhasDisciplinas.css" scoped></style>
   