using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobAdderAssignement.Logic;
using JobAdderAssignement.Model;
using System.Linq;

namespace JobAdderAssignement.Tests
{
    /// <summary>
    /// Summary description for TieBreakerTests
    /// </summary>
    [TestClass]
    public class TieBreakerTests
    {
        /// <summary>
        /// Candidate with the higher number of matching skills gets priority
        /// candidate a matches 3 skills
        /// candidate b matches 2 skills
        /// candidate a is more fit
        /// </summary>
        [TestMethod]
        public void NbSkillsTieBreaker()
        {
            ProcessedJob job = new ProcessedJob();
            job.skills = "C#, entity framework, react, jquery, mvc";
            Candidate a = new Candidate();
            a.name = "Better";
            a.skillTags = "C#, entity framework, react, cooking, painting";
            Candidate b = new Candidate();
            b.skillTags = "C#, entity framework, cooking, painting, running";

            List<Candidate> candidates = new List<Candidate>();
            candidates.Add(a);
            candidates.Add(b);

            job.Process(candidates);

            Assert.IsTrue(job.SortedCandidates.First().name == "Better");
        }

        /// <summary>
        /// If both candidate have the same number of matching skills,
        /// The lower skill weight gets priority
        /// candidate a matches 3 skills and has skill weight equal 3 (C#, entity framework, react)
        /// candidate b matched 3 skills and has skill wieght equal 7 (C#, jquery, mvc)
        /// candidate a is more fit
        /// </summary>
        [TestMethod]
        public void SkillWeightTieBreaker()
        {
            ProcessedJob job = new ProcessedJob();
            job.skills = "C#, entity framework, react, jquery, mvc";
            Candidate a = new Candidate();
            a.name = "Better";
            a.skillTags = "C#, entity framework, react, drawing, running";
            Candidate b = new Candidate();
            b.skillTags = "C#, drawing, running, jquery, mvc";

            List<Candidate> candidates = new List<Candidate>();
            candidates.Add(a);
            candidates.Add(b);

            job.Process(candidates);

            Assert.IsTrue(job.SortedCandidates.First().name == "Better");
        }

        /// <summary>
        /// If both candidate have the same number of matching skills and the same skill weight,
        /// Whoever has the lower first skilled matched index gets priority
        /// candidate a matches 2 skills and has skill weight equal 3 (C#, jquery)
        /// candidate b matched 2 skills and has skill wieght equal 3 (entity framework, react)
        /// C# is index 0, entity framework is index 1
        /// candidate a is more fit
        /// </summary>
        [TestMethod]
        public void FirstSkillIndexTieBreaker()
        {
            ProcessedJob job = new ProcessedJob();
            job.skills = "C#, entity framework, react, jquery, mvc";
            Candidate a = new Candidate();
            a.name = "Better";
            a.skillTags = "C#, cooking, running, jquery, drawing";
            Candidate b = new Candidate();
            b.skillTags = "drawing, entity framework, react, cooking, running";

            List<Candidate> candidates = new List<Candidate>();
            candidates.Add(a);
            candidates.Add(b);

            job.Process(candidates);

            Assert.IsTrue(job.SortedCandidates.First().name == "Better");
        }
    }
}
