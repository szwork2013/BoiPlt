﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protiviti.Boilerplate.Test.Support.SiteValidator {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DocPageValidatorResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DocPageValidatorResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Protiviti.Boilerplate.Test.Support.SiteValidator.DocPageValidatorResources", typeof(DocPageValidatorResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The reviewed date is older than allowed..
        /// </summary>
        public static string AgedReviewErrorMessage {
            get {
                return ResourceManager.GetString("AgedReviewErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocAgedReview.
        /// </summary>
        public static string AgedReviewErrorType {
            get {
                return ResourceManager.GetString("AgedReviewErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to   @{0} @{1} @{2}
        ///  Scenario: Page at &apos;{3}&apos; reviewed
        ///    Given I am a team member
        ///    When I navigate to the &quot;{3}&quot; page
        ///    Then the page should be reviewed and the reviewed date should be less than {4} months old.
        /// </summary>
        public static string AgedReviewResolutionScenario {
            get {
                return ResourceManager.GetString("AgedReviewResolutionScenario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} date is in the future..
        /// </summary>
        public static string FutureDateErrorMessage {
            get {
                return ResourceManager.GetString("FutureDateErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocFuture{0}Date.
        /// </summary>
        public static string FutureDateErrorType {
            get {
                return ResourceManager.GetString("FutureDateErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a value in the owner tag.  The inner text format should match &apos;Page Owner: [NAME]&apos;..
        /// </summary>
        public static string ImproperOwnerTagErrorMessage {
            get {
                return ResourceManager.GetString("ImproperOwnerTagErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocImproperOwnerTag.
        /// </summary>
        public static string ImproperOwnerTagErrorType {
            get {
                return ResourceManager.GetString("ImproperOwnerTagErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a value in the reviewer tag.  The inner text format should match &apos;Page Reviewer: [NAME]&apos;..
        /// </summary>
        public static string ImproperReviewerTagErrorMessage {
            get {
                return ResourceManager.GetString("ImproperReviewerTagErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocImproperReviewerTag.
        /// </summary>
        public static string ImproperReviewerTagErrorType {
            get {
                return ResourceManager.GetString("ImproperReviewerTagErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} date is not a valid date..
        /// </summary>
        public static string InvalidDateErrorMesssage {
            get {
                return ResourceManager.GetString("InvalidDateErrorMesssage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocInvalid{0}Date.
        /// </summary>
        public static string InvalidDateErrorType {
            get {
                return ResourceManager.GetString("InvalidDateErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to   @{0} @{1} @{2}
        ///  Scenario: Valid response from the &apos;{3}&apos; link on the page at &apos;{4}&apos;
        ///    Given I am a team member
        ///    When I navigate to the &quot;{4}&quot; page
        ///    And I click the &quot;{3}&quot; link
        ///    Then I should get a valid response.
        /// </summary>
        public static string InvalidPageLinkResolutionScenario {
            get {
                return ResourceManager.GetString("InvalidPageLinkResolutionScenario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The page does not have a properly formated {0} tag.  Please make sure it conforms to &apos;{1} on [dd/mm/yy] by [NAME]&apos;..
        /// </summary>
        public static string InvalidTagErrorMessage {
            get {
                return ResourceManager.GetString("InvalidTagErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocInvalid{0}Tag.
        /// </summary>
        public static string InvalidTagErrorType {
            get {
                return ResourceManager.GetString("InvalidTagErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The page does not have an {0} tag.  Please add &apos;&lt;p class=&quot;{0}&quot;&gt;{1} on [DATE] by [PERSON]&lt;/p&gt; to the page.  Just copy it into the markdown file and then replace the [DATE] and [PERSON] fields with the actual date and the person that {0} the page..
        /// </summary>
        public static string MissingTagErrorMessage {
            get {
                return ResourceManager.GetString("MissingTagErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocMissing{0}Tag.
        /// </summary>
        public static string MissingTagErrorType {
            get {
                return ResourceManager.GetString("MissingTagErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are multiple owner tags.  Please remove all but one..
        /// </summary>
        public static string MultipleOwnerTagsErrorMessage {
            get {
                return ResourceManager.GetString("MultipleOwnerTagsErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocMultipleOwnerTags.
        /// </summary>
        public static string MultipleOwnerTagsErrorType {
            get {
                return ResourceManager.GetString("MultipleOwnerTagsErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are multiple reviewer tags.  Please remove all but one..
        /// </summary>
        public static string MultipleReviewerTagsErrorMessage {
            get {
                return ResourceManager.GetString("MultipleReviewerTagsErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocMultipleReviewerTags.
        /// </summary>
        public static string MultipleReviewerTagsErrorType {
            get {
                return ResourceManager.GetString("MultipleReviewerTagsErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are multiple {0} tags.  Please remove all but one..
        /// </summary>
        public static string MultipleTagsErrorMessage {
            get {
                return ResourceManager.GetString("MultipleTagsErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocMultiple{0}Tags.
        /// </summary>
        public static string MultipleTagsErrorType {
            get {
                return ResourceManager.GetString("MultipleTagsErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Page Owner:(.*).
        /// </summary>
        public static string OwnerRegex {
            get {
                return ResourceManager.GetString("OwnerRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to owner.
        /// </summary>
        public static string OwnerTagName {
            get {
                return ResourceManager.GetString("OwnerTagName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to p.owner.
        /// </summary>
        public static string OwnerTagSelector {
            get {
                return ResourceManager.GetString("OwnerTagSelector", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OWNER.
        /// </summary>
        public static string PageStateKeyOwner {
            get {
                return ResourceManager.GetString("PageStateKeyOwner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to REVIEWED_DATE.
        /// </summary>
        public static string PageStateKeyReviewedDate {
            get {
                return ResourceManager.GetString("PageStateKeyReviewedDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to REVIEWED_PERSON.
        /// </summary>
        public static string PageStateKeyReviewedPerson {
            get {
                return ResourceManager.GetString("PageStateKeyReviewedPerson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to REVIEWER.
        /// </summary>
        public static string PageStateKeyReviewer {
            get {
                return ResourceManager.GetString("PageStateKeyReviewer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATED_DATE.
        /// </summary>
        public static string PageStateKeyUpdatedDate {
            get {
                return ResourceManager.GetString("PageStateKeyUpdatedDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATED_PERSON.
        /// </summary>
        public static string PageStateKeyUpdatedPerson {
            get {
                return ResourceManager.GetString("PageStateKeyUpdatedPerson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to reviewed.
        /// </summary>
        public static string ReviewedTagName {
            get {
                return ResourceManager.GetString("ReviewedTagName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Page Reviewer:(.*).
        /// </summary>
        public static string ReviewerRegex {
            get {
                return ResourceManager.GetString("ReviewerRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to reviewer.
        /// </summary>
        public static string ReviewerTagName {
            get {
                return ResourceManager.GetString("ReviewerTagName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to p.reviewer.
        /// </summary>
        public static string ReviewerTagSelector {
            get {
                return ResourceManager.GetString("ReviewerTagSelector", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} on ((\d|\d\d)\/(\d|\d\d)\/(\d|\d\d|\d\d\d\d)) by (.+).
        /// </summary>
        public static string TagMatcher {
            get {
                return ResourceManager.GetString("TagMatcher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to p.{0}.
        /// </summary>
        public static string TagSelector {
            get {
                return ResourceManager.GetString("TagSelector", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unassigned.
        /// </summary>
        public static string UnassignedReviewerName {
            get {
                return ResourceManager.GetString("UnassignedReviewerName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The reviewed date is older than the updated date..
        /// </summary>
        public static string UnreviewedChangeErrorMessage {
            get {
                return ResourceManager.GetString("UnreviewedChangeErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DocUnreviewedChange.
        /// </summary>
        public static string UnreviewedChangeErrorType {
            get {
                return ResourceManager.GetString("UnreviewedChangeErrorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to   @{0} @{1} @{2}
        ///  Scenario: Page at &apos;{3}&apos; reviewed
        ///    Given I am a team member
        ///    When I navigate to the &quot;{3}&quot; page
        ///    Then the page should be reviewed and the reviewed date should be after the updated date.
        /// </summary>
        public static string UnreviewedChangeResolutionScenario {
            get {
                return ResourceManager.GetString("UnreviewedChangeResolutionScenario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to updated.
        /// </summary>
        public static string UpdatedTagName {
            get {
                return ResourceManager.GetString("UpdatedTagName", resourceCulture);
            }
        }
    }
}
