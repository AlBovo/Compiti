import org.junit.jupiter.api.*

class PlaylistTest{
    @Test
    fun theSizeOfThePlaylistCannotBeNegative(){
        assertThrows<IllegalArgumentException>{ Playlist(-1) }
    }
    @Test
    fun addMusic_cannotAddASongIfThePlaylistIsFilled(){
        val playlist = Playlist(5)
        for(i in 0 until 5){
            playlist.addMusic("Le tagliatelle di Nonna Pina", 6.9)
        }
        assertThrows<IllegalStateException> { playlist.addMusic("Inno Francese", 1.0) }
    }
    @Test
    fun addMusic_theFunctionRemoveMusicReturnTheCorrectValue(){
        val playlist = Playlist(5)
        val expected = "Wake me up"
        playlist.addMusic("Wake me up", 2.0)
        Assertions.assertEquals(expected, playlist.removeMusic())
    }
    @Test
    fun songInit_theDurationCannotBeNegative(){
        val playlist = Playlist(5)
        assertThrows<IllegalArgumentException> { playlist.addMusic("Hey Ja", -4.0) }
    }
    @Test
    fun removeMusic_cannotRemoveASongIfThePlaylistIsEmpty(){
        val playlist = Playlist(5)
        assertThrows<IllegalStateException> { playlist.removeMusic() }
    }
    @Test
    fun removeMusic_ifTwoSongsAreAddedRemoveMusicReturnTheFirstOne(){
        val playlist = Playlist(4)
        playlist.addMusic("Amore e odio", 3.2)
        playlist.addMusic("Never Gonna Give You Up (NGGYP)", 2.1)
        val expected = "Amore e odio"
        Assertions.assertEquals(expected, playlist.removeMusic())
    }
    @Test
    fun totalDuration_theTotalDurationIsZeroAtTheInit(){
        val playlist = Playlist(3)
        val expected = 0.0
        Assertions.assertEquals(expected, playlist.totalDuration())
    }
    @Test
    fun totalDuration_theTotalDurationOfTwoSongsIsTheSumOfTheirDuration(){
        val playlist = Playlist(5)
        playlist.addMusic("Non so che cantare", 3.2)
        playlist.addMusic("Pulcino pio", 2.3)
        val expected = 3.2 + 2.3
        Assertions.assertEquals(expected, playlist.totalDuration())
    }
}