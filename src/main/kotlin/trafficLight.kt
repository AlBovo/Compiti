class TrafficLight(val type: Int){
    var status: Int = 0 // 0: Rosso, 1: Giallo, 2: Verde
        private set(value){
            when (value) {
                0 -> {
                    println("Now the color is red")
                }
                1 -> {
                    println("Now the color is yellow")
                }
                2 -> {
                    println("Now the color is green")
                }
            }
            field = value
        }
    init{
        require(type == 0 || type == 1){
            "The type it's not correct"
        }
    }
    fun changeStatus(newStatus: Int){
        require(newStatus != status){
            "The new status must be different from the actual"
        }
        require(newStatus == 0 || newStatus == 2) {
            "The new status it's not correct"
        }
        if(type == 0){ // Italiano
            if(status == 0){
                status = 2
            }
            else{
                status = 1
                status = 0
            }
        } else {
            if(status == 0){
                status = 1
                status = 2
            }
            else{
                status = 1
                status = 0
            }
        }
    }
}