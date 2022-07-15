using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cysharp.Threading.Tasks;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Sdk.Exceptions;
//using MoralisUnity.MoralisWesb3ApiSdk;
using MoralisUnity.Platform.Queries;
using MoralisUnity;
public class ArtworkSubmissionData : MoralisObject {
    public Sprite subImage { get; set; }
    public string artworkTitle { get; set; }
    public string artistWalletAddress { get; set; }
    public int totalBumps { get; set; }
    public string desc { get; set; }
    public Dictionary<int, string> supporters = new Dictionary<int, string>();    
    public ArtworkSubmissionData() : base("ArtworkSubmissionData") {}
}
public class GameController : MonoBehaviour
{
    public bool isContestRunning;

    public int winningPot;
    public List<ArtworkSubmissionData> ArtSubmissions = new List<ArtworkSubmissionData>();
    //public Dictionary<int, string> supporters = new Dictionary<int, string>();
    // Start is called before the first frame update
    void Start()
    {
        GetSubmissions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async UniTask GetSubmissions()
    {
        MoralisQuery<ArtworkSubmissionData> query = Moralis.GetClient().Query<ArtworkSubmissionData>();
        IEnumerable<ArtworkSubmissionData> ArtSubmissions = await query.FindAsync();

        var artworkList = ArtSubmissions.ToList();
        if (artworkList.Any())
        {
            foreach (var artwork in artworkList)
            {   
                ArtSubmissions.Add(artwork);
            }
        }
    }
    private async UniTask CreateSubmission()
    {
        //Create Artwork Moralis Object and SAVE it to the database
        ArtworkSubmissionData newArtwork = Moralis.GetClient().Create<ArtworkSubmissionData>();
        newArtwork.artworkTitle = "Hello";
        
        var result = await newArtwork.SaveAsync();

        if (result)
        {
            //Getting the last enemy saved in the DB = The Enemy we just created.
            MoralisQuery<ArtworkSubmissionData> query = Moralis.GetClient().Query<ArtworkSubmissionData>().OrderByDescending("createdAt").Limit(1);
            IEnumerable<ArtworkSubmissionData> artworks = await query.FindAsync();

            var artworkList = artworks.ToList();
            if (artworkList.Any())
            {
                ArtSubmissions.Add(artworkList[0]);
            }
        }
    }
}
