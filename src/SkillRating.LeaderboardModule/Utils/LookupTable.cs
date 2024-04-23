namespace SkillRating.LeaderboardModule.Utils;

internal sealed class LookupTable
{
    private readonly List<Guid> _ids = [];
    private readonly Dictionary<Guid, int> _idToIndex = new();

    public int Count => _ids.Count;

    public Guid GetId(int index)
    {
        return _ids[index];
    }

    public int GetIndex(Guid id)
    {
        if (_idToIndex.TryGetValue(id, out var result))
            return result;

        result = Count;
        _idToIndex.Add(id, result);
        _ids.Add(id);

        return result;
    }
}
