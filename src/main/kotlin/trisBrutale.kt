// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class Player{
    var points = 0
    var statistics = 0.0
    var games = 1
        set(value){
            require(field < value){
                "Number of games must increase"
            }
            field = value
        }
    var name = ""
        set(value){
            require(value != ""){
                "You must enter a valid name"
            }
            field = value
        }
}
fun printScheme(listPositions: Array<Array<String>>){
    val scheme = " ${listPositions[0][0]} | ${listPositions[0][1]} | ${listPositions[0][2]} \n" +
                 " ---------- \n" +
                 " ${listPositions[1][0]} | ${listPositions[1][1]} | ${listPositions[1][2]} \n" +
                 " ---------- \n" +
                 " ${listPositions[2][0]} | ${listPositions[2][1]} | ${listPositions[2][2]} \n"
    print(scheme)
    return
}

fun isFilled(listPositions: Array<Array<String>>): Boolean{
    for(i in 0..2){
        for(e in 0..2){
            if(listPositions[i][e] == " "){
                return false
            }
        }
    }
    return true
}

fun isWon(listPositions: Array<Array<String>>): Boolean{
    for(i in 0..2){
        var bool = true
        for(e in 0..2){
            bool = bool && listPositions[i][e] == "X"
        }
        if(bool){
            return true
        }
    }
    for(i in 0..2){
        var bool = true
        for(e in 0..2){
            bool = bool && listPositions[e][i] == "X"
        }
        if(bool){
            return true
        }
    }
    if(listPositions[0][0] == "X" && listPositions[1][1] == "X" && listPositions[2][2] == "X"){
        return true
    }
    if(listPositions[0][2] == "X" && listPositions[1][1] == "X" && listPositions[2][0] == "X"){
        return true
    }
    return false
}

fun isLost(listPositions: Array<Array<String>>): Boolean{
    for(i in 0..2){
        var bool = true
        for(e in 0..2){
            bool = bool && listPositions[i][e] == "O"
        }
        if(bool){
            return true
        }
    }
    for(i in 0..2){
        var bool = true
        for(e in 0..2){
            bool = bool && listPositions[e][i] == "O"
        }
        if(bool){
            return true
        }
    }
    if(listPositions[0][0] == "O" && listPositions[1][1] == "O" && listPositions[2][2] == "O"){
        return true
    }
    if(listPositions[0][2] == "O" && listPositions[1][1] == "O" && listPositions[2][0] == "O"){
        return true
    }
    return false
}

fun findBestMove(listPositions: Array<Array<String>>, myTurn: Boolean): Int{
    if(isWon(listPositions)){
        return 1
    } else if(isLost(listPositions)){
        return 0
    }
    var counter = 0
    for(i in 0..2){
        for(e in 0..2){
            if(listPositions[i][e] == " "){
                if(myTurn){
                    listPositions[i][e] = "O"
                    counter += findBestMove(listPositions, false)
                    listPositions[i][e] = " "
                } else {
                    listPositions[i][e] = "X"
                    counter += findBestMove(listPositions, true)
                    listPositions[i][e] = " "
                }
            }
        }
    }
    return counter
}
fun chooseMove(listPositions: Array<Array<String>>): Pair<Int, Int> {
    val possibleCombinations: MutableList<Pair<Int, Int>> = mutableListOf()
    var bestDecision = Pair(1e8.toInt(), Pair(-1, -1))
    for(i in 0..2){
        for(e in 0..2){
            if(listPositions[i][e] == " "){
                possibleCombinations.add(Pair(i, e))
            }
        }
    }
    for(i in possibleCombinations){
        listPositions[i.first][i.second] = "O"
        val solution = findBestMove(listPositions.clone(), false)
        if(solution < bestDecision.first){
            bestDecision = Pair(solution, Pair(i.first, i.second))
            // printScheme(bestDecision.second)
            // print(i)
            // println(solution)
        }
        listPositions[i.first][i.second] = " "
    }
    return bestDecision.second
}
fun main(){
    val player = Player()
    print("Enter your name: ")
    player.name = readln()
    while(true){
        if(player.games == 1){
            println("\nWelcome ${player.name}, this is the famous tris game but on terminal, good luck!")
        } else {
            print("You have ${player.points} points (w/l = ${player.statistics}), do you want to play an another round [Y/n]? ")
            val response = readln()
            if(response.lowercase() == "n"){
                break
            }
        }
        var listPositions: Array<Array<String>> = arrayOf(arrayOf(" ", " " , " "), arrayOf(" ", " " , " "), arrayOf(" ", " " , " "))
        var finished = false
        while(!finished){
            printScheme(listPositions)
            print("Enter the coordinates, x(1,2,3): ")
            val x = readln().toInt()-1
            require(x in 0..2){
                "The x must be in the range "
            }
            print("Enter the coordinates, y(1,2,3): ")
            val y = readln().toInt()-1
            require(y in 0..2){
                "The y must be in the range"
            }
            require(listPositions[x][y] == " "){
                "The place must be empty"
            }
            listPositions[x][y] = "X"
            finished = isWon(listPositions) || isLost(listPositions) || isFilled(listPositions)
            if(isWon(listPositions)){
                println("\nYou won, nice game!")
                player.points++
            } else if(isLost(listPositions)){
                println("\nYou lost, try again!")
                player.points--
            } else if(isFilled(listPositions)) {
                println("\nYou tied, try again!")
            } else{
                var newCoordinates = chooseMove(listPositions)
                listPositions[newCoordinates.first][newCoordinates.second] = "O"
            }
        }
        player.statistics = player.points.toDouble() / player.games.toDouble()
        player.games++
    }
}