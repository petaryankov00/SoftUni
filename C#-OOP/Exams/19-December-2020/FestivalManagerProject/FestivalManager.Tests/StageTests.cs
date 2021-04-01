// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	using FestivalManager.Entities;
	using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp]
		public void SetUp()
		{
			stage = new Stage();
		}


		[Test]
		public void CtorTestIfNotNull()
		{
			Assert.IsNotNull(stage);
		}
		[Test]
		public void IReadOnlyPerformersIsNotNull()
		{
			Assert.IsNotNull(stage.Performers);
		}

		[Test]
		public void When_InitilizeStage_ShouldHaveListOfPerfomers()
		{
			Assert.AreEqual(stage.Performers.Count, 0);
		}

		[Test]
	    public void When_AddPerformerUnder18_ShouldThrowException()
	    {
			Performer performer = new Performer("Pesho", "Ivanov", 17);

			Assert.Throws<ArgumentException>(() =>
			{ 
				stage.AddPerformer(performer);
			});
		
		}

		[Test]
		public void When_AddPerformerUnder18_ShouldAddCorrect()
		{
			Performer performer = new Performer("Pesho", "Ivanov", 20);
			Performer performer2 = new Performer("Ivan", "Ivanov", 19);
			stage.AddPerformer(performer);
			stage.AddPerformer(performer2);

			Assert.That(stage.Performers.Count, Is.EqualTo(2));

		}



		[Test]
		public void When_AddSongUnderOneMinute_ShouldThrowException()
		{
			Song song = new Song("Value", new TimeSpan());

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});
		}

		[Test]
		public void When_AddSongToPerformer_ShouldAddCorrect()
		{
			Performer performer = new Performer("Pesho", "Ivanov", 19);
			Song song = new Song("Value", new TimeSpan(12, 23, 30));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.AreEqual($"{song} will be performed by {performer.FullName}",
				stage.AddSongToPerformer("Value", performer.FullName));
		}

		[Test]
		public void When_Play_ShouldReturnString()
		{
			string result = stage.Play();
			Assert.That(result, Is.TypeOf<string>());
		}

		[Test]
		public void AddSongToPerformerNullSong()
		{
			Performer validPerformer = new Performer("tsa", "tsav", 20);

			Assert.That(() => stage.AddSongToPerformer(null, validPerformer.FullName), Throws.ArgumentNullException);
		}

		[Test]
		public void AddPerformerWithNullPerformerException()
		{
			Performer performerNull = null;
			Assert.That(() => stage.AddPerformer(performerNull), Throws.ArgumentNullException);
		}

		[Test]
		public void AddSongWithNull()
		{
			Song songNull = null;
			Assert.That(() => stage.AddSong(songNull), Throws.ArgumentNullException);
		}

		[Test]
		public void AddSongToPerformerNullPerformer()
		{
			Song song = new Song("Value", new TimeSpan(12, 23, 30));
			Assert.That(() => stage.AddSongToPerformer(song.Name, null), Throws.ArgumentNullException);
		}

		[Test]
		public void PlayStringResult()
		{
			Performer validPerformer = new Performer("tsa", "tsav", 20);
			Song validSong = new Song("Value", new TimeSpan(23,23,23));

			stage.AddPerformer(validPerformer);
			stage.AddSong(validSong);
			stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);
			Assert.AreEqual("1 performers played 1 songs", stage.Play());
		}

	}
}