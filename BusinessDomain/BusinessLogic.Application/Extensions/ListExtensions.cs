namespace BusinessLogic.Application.Extensions;
public static class ListExtensions
{
    public static void AddRangeMany<T>(this List<T> alist, params List<T>[] concatenatedLists)
    {
        int length = concatenatedLists.Length;
        for (int i = 0; i < length; i++)
        {
            alist.AddRange(concatenatedLists[i]);
        }
    }
}