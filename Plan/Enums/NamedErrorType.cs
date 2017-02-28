namespace PlanService.Enums
{
    public enum ErrorType
    {
        PlanWebsiteError = 1,
        JsonParsingError = 2,
        PlanWebsiteRequestError = 3,
        ForStudiesOptionsHtmlParsingError = 4,
        YearAndFieldParsingError = 5,
        SpecializationsParsingError = 6,
        GroupAndLectoratesParsingError = 7,
        AddressBuildError = 8,
        ClassesParsingError = 9,
        ClassesMergeError = 10,
        SeminarHtmlParsingError = 11,
        FacultyHtmlParsingError = 12,
        ChangesHtmlParsingError = 13,
    }
}