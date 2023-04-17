import kotlin.random.Random
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class Bingo{
    private var numbersExtracted = Array(91) { false }
    fun extractNumber(): Int{
        require(!isEmpty()){
            "The bag cannot be empty"
        }
        var number = Random.nextInt(1, 91)
        while(numbersExtracted[number]){
            number = Random.nextInt(1, 91)
        }
        check(!numbersExtracted[number]){
            "The number extracted must not be already extracted"
        }
        println("The number: $number has been extracted")
        numbersExtracted[number] = true
        return number
    }
    fun isEmpty(): Boolean{
        var test = true
        for(i in 1..90){
            test = test and numbersExtracted[i]
        }
        return test
    }
}