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
    /// Tests to verify we extract the fitness values as expected, 
    /// these are critical as we'll use these value in our tie breaker methods later on
    /// </summary>
    [TestClass]
    public class FitnessValuesTest
    {
        /// <summary>
        /// Checking the number of matching skills is correct
        /// Expecting 3 skills to match
        /// </summary>
        [TestMethod]
        public void NbSkillMatching()
        {
            string jobskills = "C#, entity framework, react, jquery, mvc";
            string candidateskills = "react, mvc, C#, cooking, painting";
            ProcessedCandidate candidate = new ProcessedCandidate();
            candidate.skillTags = candidateskills;

            candidate.Process(jobskills);

            Assert.AreEqual(candidate.NbSkillMatching, 3);
        }

        /// <summary>
        /// Checking calculation of skill weight
        /// Matching skills are at index 2 and 4
        /// Expecting 6 to be returned
        /// </summary>
        [TestMethod]
        public void SkillWeight()
        {
            string jobskills = "C#, entity framework, react, jquery, mvc";
            string candidateskills = "react, mvc, C#, cooking, painting";
            ProcessedCandidate candidate = new ProcessedCandidate();
            candidate.skillTags = candidateskills;

            candidate.Process(jobskills);

            Assert.AreEqual(candidate.SkillWeight, 6);
        }

        /// <summary>
        /// Checking the first matching skill index
        /// First skill to match is react (index 3)
        /// Expected result : 3
        /// </summary>
        [TestMethod]
        public void FirstSkillMatchedIndex()
        {
            string jobskills = "C#, entity framework, react, jquery, mvc";
            string candidateskills = "react, mvc, cooking, painting";
            ProcessedCandidate candidate = new ProcessedCandidate();
            candidate.skillTags = candidateskills;

            candidate.Process(jobskills);

            Assert.AreEqual(candidate.FirstSkillMatchedIndex, 3);
        }

        /// <summary>
        /// Checking percentage of skills matching
        /// Candidate matches 2 out of 5 skills from the job
        /// Expected result 40%
        /// </summary>
        [TestMethod]
        public void PercentSkills()
        {
            string jobskills = "C#, entity framework, react, jquery, mvc";
            string candidateskills = "react, mvc, cooking, painting";
            ProcessedCandidate candidate = new ProcessedCandidate();
            candidate.skillTags = candidateskills;

            candidate.Process(jobskills);

            Assert.AreEqual(candidate.PercentSkills, 40);
        }
    }
}
