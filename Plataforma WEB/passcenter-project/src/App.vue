<template>
  <div>
    <router-view />
    <div class="cro canvas">
      <div class="center">
        <input type="checkbox" checked id="switch" />
        <label class="pause-play-icon" for="switch"></label>

        <a href="https://docs.google.com/forms/d/e/1FAIpQLSfejixd0upXhPogUSfYNLrWQqjomAxpW-q1N8lzn9hWdz0eww/viewform?usp=sf_link" target="_blank"><i class="icone material-icons link">rate_review</i></a>
        <div class="clock">
          <div class="hours"></div>
          <span class="dots">:</span>
          <div class="minutes"></div>
          <span class="dots">:</span>
          <div class="seconds"></div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "app"
};
</script>
<style>
*, *:before, *:after {
    margin: 0;
    padding: 0;
    -webkit-box-sizing: border-box;
            box-sizing: border-box;
}

.link{
  position: absolute;
  top:5%;
  left: 43%;
  color: #FFF;
  border-width: 2px;
  border-color: #FFF;
  border-style: solid;
  padding: 5px;
  border-radius: 100px ;
}
.cro {
    background: #f0f0f0;
    color: #FFF;
    font-family: "Open Sans", sans-serif;
}

.canvas {
    width: 300px;
    height: 200px;
    -webkit-box-shadow: 1px 2px 10px 0px rgba(0,0,0,0.3);
            box-shadow: 1px 2px 10px 0px rgba(0,0,0,0.3);
    background: white;
    border-radius: 3px;
    position: fixed;
    top: 88%;
    left: 91%;
    opacity: 0.05;
    transition: 0.5s;
    -webkit-transform: translate(-50%,-50%) ;
        -ms-transform: translate(-50%,-50%) ;
            transform: translate(-50%,-50%) ;
}
.canvas:hover{
    opacity: 1;
    transition: 0.5s;
}

.canvas>.center {
    position: absolute;
    background: -webkit-gradient(linear,right top, left bottom,color-stop(80%, rgb(101, 148, 255)),color-stop(80%, rgba(101, 48, 255, 0)),color-stop(82%, rgba(255, 255, 255, 0)),color-stop(82%, rgb(65, 65, 65)));
    background: -webkit-linear-gradient(top right,rgb(101, 148, 255) 80%,rgba(101, 48, 255, 0) 80%,rgba(255, 255, 255, 0) 82%,rgb(65, 65, 65) 82%);
    background: -o-linear-gradient(top right,rgb(101, 148, 255) 80%,rgba(101, 48, 255, 0) 80%,rgba(255, 255, 255, 0) 82%,rgb(65, 65, 65) 82%);
    background: linear-gradient(to bottom left,rgb(101, 148, 255) 80%,rgba(101, 48, 255, 0) 80%,rgba(255, 255, 255, 0) 82%,rgb(65, 65, 65) 82%);
    width: 300px;
    height: 200px;
    top: 88%;
    -webkit-box-shadow: 1px 2px 10px 0px rgba(0,0,0,0.3);
            box-shadow: 1px 2px 10px 0px rgba(0,0,0,0.3);
    border-radius: 3px;
    left: 58%;
    margin: -175px 0 0 -175px;
    overflow: hidden;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-orient: horizontal;
    -webkit-box-direction: normal;
        -ms-flex-direction: row;
            flex-direction: row;
    -webkit-box-pack: center;
        -ms-flex-pack: center;
            justify-content: center;
}

.canvas>.center>.clock {
    border: 7px solid rgb(65, 65, 65);
    position: absolute;
    border-radius: 3px;
    -ms-flex-item-align: center;
        align-self: center;
    padding: 15px 40px;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-shadow: 1px 2px 10px 0px rgba(0,0,0,0.3);
            box-shadow: 1px 2px 10px 0px rgba(0,0,0,0.3);
}

.canvas>.center>.clock>.dots {
    font-size: 2em;
    font-weight: 900;
    margin-top: -2px;
}

.canvas>.center>.clock>.hours:after,.canvas>.center>.clock>.hours:before,.canvas>.center>.clock>.minutes:before,.canvas>.center>.clock>.minutes:after,.canvas>.center>.clock>.hours:before,.canvas>.center>.clock>.seconds:after,.canvas>.center>.clock>.seconds:before {
    content: '0';
    font-size: 2em;
    font-weight: 900;
    -webkit-animation: var(--name) var(--duration) steps(1) infinite;
            animation: var(--name) var(--duration) steps(1) infinite;
}

.canvas>.center>.clock>.hours:after {
    --name:right; --duration:2160000s; }

.canvas>.center>.clock>.hours:before {
    --name:left; --duration:21600000s; }

.canvas>.center>.clock>.minutes:after {
    --name:right; --duration:600s; }

.canvas>.center>.clock>.minutes:before {
    --name:left; --duration:3600s; }

.canvas>.center>.clock>.seconds:after {
    --name:right; --duration:10s; }

.canvas>.center>.clock>.seconds:before {
    --name:left; --duration:60s; }

@-webkit-keyframes right {
    0% {
        content: '0';
    }

    10% {
        content: '1';
    }

    20% {
        content: '2';
    }

    30% {
        content: '3';
    }

    40% {
        content: '4';
    }

    50% {
        content: '5';
    }

    60% {
        content: '6';
    }

    70% {
        content: '7';
    }

    80% {
        content: '8';
    }

    90% {
        content: '9';
    }
}

@keyframes right {
    0% {
        content: '0';
    }

    10% {
        content: '1';
    }

    20% {
        content: '2';
    }

    30% {
        content: '3';
    }

    40% {
        content: '4';
    }

    50% {
        content: '5';
    }

    60% {
        content: '6';
    }

    70% {
        content: '7';
    }

    80% {
        content: '8';
    }

    90% {
        content: '9';
    }
}

@-webkit-keyframes left {
    0% {
        content: '0';
    }

    16.666666666666668% {
        content: '1';
    }

    33.333333333333336% {
        content: '2';
    }

    50% {
        content: '3';
    }

    66.66666666666667% {
        content: '4';
    }

    83.33333333333334% {
        content: '5';
    }
}

@keyframes left {
    0% {
        content: '0';
    }

    16.666666666666668% {
        content: '1';
    }

    33.333333333333336% {
        content: '2';
    }

    50% {
        content: '3';
    }

    66.66666666666667% {
        content: '4';
    }

    83.33333333333334% {
        content: '5';
    }
}

#switch,#reset {
    display: none;
}

.canvas>.center>.pause-play-icon {
    color: #414141;
    position: absolute;
    border: 5px solid ;
    border-radius: 50%;
    left: 43%;
    top: 76%;
    bottom: 22%;
    height: 40px;
    width: 40px;
    cursor: pointer;
}

.canvas>.center>.reset-icon {
    color: #414141;
    position: absolute;
    border: 5px solid ;
    border-radius: 50%;
    right: 35%;
    bottom: 22%;
    top: 76%;
    height: 40px;
    width: 40px;
    cursor: pointer;
}

.canvas>.center>.reset-icon:before {
    content: '';
    color: inherit;
    position: absolute;
    left: 50%;
    top: 50%;
    margin-left: -6.5px;
    margin-top: -6.5px;
    border: 7px solid ;
    -webkit-transition: opacity 1.5s;
    -o-transition: opacity 1.5s;
    transition: opacity 1.5s;
    opacity: 1;
}

.canvas>.center>.pause-play-icon:hover,.canvas>.center>.reset-icon:hover{
    color: rgb(77, 77, 77);
}

.canvas>.center>.pause-play-icon:active,.canvas>.center>.reset-icon:active {
    color: rgb(40, 40, 40);
}

.canvas>.center>.pause-play-icon:before {
    content: '';
    color: inherit;
    position: absolute;
    height: 13px;
    width: 10px;
    left: 50%;
    top: 50%;
    margin-left: -5px;
    margin-top: -6.5px;
    border: 4px solid ;
    border-top: none;
    border-bottom: none;
    -webkit-transition: opacity 1.5s;
    -o-transition: opacity 1.5s;
    transition: opacity 1.5s;
    opacity: 1;
}

.canvas>.center>.pause-play-icon:after {
    content: '';
    color: inherit;
    position: absolute;
    top: 50%;
    left: 50%;
    margin-top: -9.5px;
    margin-left: -3.5px;
    -webkit-transform: scale(0);
        -ms-transform: scale(0);
            transform: scale(0);
    border: 10px solid ;
    border-top-color: rgba(0, 0, 0, 0);
    border-right-color: rgba(0, 0, 0, 0);
    border-bottom-color: rgba(0, 0, 0, 0);
    -webkit-transition: opacity 1.5s;
    -o-transition: opacity 1.5s;
    transition: opacity 1.5s;
    opacity: 0;
}

#switch:checked ~ .pause-play-icon:before {
    -webkit-transform: scale(0);
        -ms-transform: scale(0);
            transform: scale(0);
    opacity: 0;
}

#switch:checked ~ .pause-play-icon:after {
    -webkit-transform: scale(1);
        -ms-transform: scale(1);
            transform: scale(1);
    opacity: 1;
}

#switch:checked ~ .clock>.hours:before, #switch:checked ~ .clock>.hours:after, #switch:checked ~ .clock>.minutes:before, #switch:checked ~ .clock>.minutes:after, #switch:checked ~ .clock>.seconds:before, #switch:checked ~ .clock>.seconds:after {
    -webkit-animation-play-state: paused;
            animation-play-state: paused;
}

#reset:checked ~ .clock>.hours:after {
    --name:reset-right; 
    --duration:2160000s; 
}

#reset:checked ~ .clock>.hours:before {
    --name:reset-left; 
    --duration:21600000s; 
}

#reset:checked ~ .clock>.minutes:after {
    --name:reset-right; 
    --duration:600s; 
}

#reset:checked ~ .clock>.minutes:before {
    --name:reset-left; 
    --duration:3600s; 
}

#reset:checked ~ .clock>.seconds:after {
    --name:reset-right; 
    --duration:10s; 
}

#reset:checked ~ .clock>.seconds:before {
    --name:reset-left; 
    --duration:60s; 
}

@-webkit-keyframes reset-right {
    0% {
        content: '0';
    }

    10% {
        content: '1';
    }

    20% {
        content: '2';
    }

    30% {
        content: '3';
    }

    40% {
        content: '4';
    }

    50% {
        content: '5';
    }

    60% {
        content: '6';
    }

    70% {
        content: '7';
    }

    80% {
        content: '8';
    }

    90% {
        content: '9';
    }
}

@keyframes reset-right {
    0% {
        content: '0';
    }

    10% {
        content: '1';
    }

    20% {
        content: '2';
    }

    30% {
        content: '3';
    }

    40% {
        content: '4';
    }

    50% {
        content: '5';
    }

    60% {
        content: '6';
    }

    70% {
        content: '7';
    }

    80% {
        content: '8';
    }

    90% {
        content: '9';
    }
}

@-webkit-keyframes reset-left {
    0% {
        content: '0';
    }

    16.666666666666668% {
        content: '1';
    }

    33.333333333333336% {
        content: '2';
    }

    50% {
        content: '3';
    }

    66.66666666666667% {
        content: '4';
    }

    83.33333333333334% {
        content: '5';
    }
}

@keyframes reset-left {
    0% {
        content: '0';
    }

    16.666666666666668% {
        content: '1';
    }

    33.333333333333336% {
        content: '2';
    }

    50% {
        content: '3';
    }

    66.66666666666667% {
        content: '4';
    }

    83.33333333333334% {
        content: '5';
    }
}
</style>

