fun isNumberPerfect(number: Int): Boolean{
    require(number > 0){
        "The number must be positive"
    }
    var sum = 0
    for(i in 1 until number){
        if(number % i == 0){
            sum += i
        }
    }
    return sum == number
}