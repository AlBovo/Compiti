// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class TrafficLight(val type: Int){
    var status: Int = 0 // 0: Rosso, 1: Giallo, 2: Verde
        private set
    init{
        require(type == 0 || type == 1){
            "The type it's not correct"
        }
    }
    fun changeStatusGreater(){
        check(status in 0..1){
            "Status out of range"
        }
        if(type == 0){ // Italiano
            status = 2
        } else {
            status++
        }
    }
    fun changeStatusLess(){
        check(status in 1..2){
            "Status out of range"
        }
        status--
    }
}