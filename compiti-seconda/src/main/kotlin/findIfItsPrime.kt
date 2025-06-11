import kotlin.math.*
fun findIfItsPrime(number: Int): Boolean{
    require(number > 1){
        "The number must be greater than 1"
    }
    for(i in 2..sqrt(number.toDouble()).toInt()){
        if(number % i == 0){
            return false
        }
    }
    return true
}