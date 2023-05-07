class Playlist(maxNumberOfSongs: Int){
    class Song(nameValue: String, durationValue: Double){
        val name: String
        val duration: Double
        init{
            require(durationValue > 0.0){
                "The duration must be positive"
            }
            name = nameValue
            duration = durationValue
        }
    }
    private val songs: Array<Song>
    private var playListPointer = 0
    init{
        require(maxNumberOfSongs > 0){
            "The size of the playlist must be positive"
        }
        songs = Array(maxNumberOfSongs){ Song("", 3.0) }
    }
    fun addMusic(name: String, duration: Double){
        check(playListPointer < songs.size){
            "The playlist is already filled"
        }
        val song = Song(name, duration)
        songs[playListPointer] = song
        playListPointer += 1
    }
    fun removeMusic(): String{
        check(playListPointer > 0){
            "You cannot remove a song if the playlist is empty"
        }
        val name = songs[0].name
        for(i in 1 until playListPointer){
            songs[i-1] = songs[i]
        }
        playListPointer -= 1
        return name
    }
    fun totalDuration(): Double{
        var totalDuration = 0.0
        for(i in 0 until playListPointer){
            totalDuration += songs[i].duration
        }
        return totalDuration
    }
}