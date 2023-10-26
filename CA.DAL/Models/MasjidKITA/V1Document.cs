using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Document
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Content { get; set; }

    public long Version { get; set; }

    public virtual ICollection<V1Aliaspartindex> V1Aliaspartindices { get; set; } = new List<V1Aliaspartindex>();

    public virtual ICollection<V1Autoroutepartindex> V1Autoroutepartindices { get; set; } = new List<V1Autoroutepartindex>();

    public virtual ICollection<V1Containedpartindex> V1Containedpartindices { get; set; } = new List<V1Containedpartindex>();

    public virtual ICollection<V1Contentitemindex> V1Contentitemindices { get; set; } = new List<V1Contentitemindex>();

    public virtual ICollection<V1Deploymentplanindex> V1Deploymentplanindices { get; set; } = new List<V1Deploymentplanindex>();

    public virtual ICollection<V1Layermetadataindex> V1Layermetadataindices { get; set; } = new List<V1Layermetadataindex>();

    public virtual ICollection<V1Localizedcontentitemindex> V1Localizedcontentitemindices { get; set; } = new List<V1Localizedcontentitemindex>();

    public virtual ICollection<V1Taxonomyindex> V1Taxonomyindices { get; set; } = new List<V1Taxonomyindex>();

    public virtual ICollection<V1Userbyclaimindex> V1Userbyclaimindices { get; set; } = new List<V1Userbyclaimindex>();

    public virtual ICollection<V1Userbylogininfoindex> V1Userbylogininfoindices { get; set; } = new List<V1Userbylogininfoindex>();

    public virtual ICollection<V1Userindex> V1Userindices { get; set; } = new List<V1Userindex>();

    public virtual ICollection<V1Workflowblockingactivitiesindex> V1Workflowblockingactivitiesindices { get; set; } = new List<V1Workflowblockingactivitiesindex>();

    public virtual ICollection<V1Workflowindex> V1Workflowindices { get; set; } = new List<V1Workflowindex>();

    public virtual ICollection<V1Workflowtypeindex> V1Workflowtypeindices { get; set; } = new List<V1Workflowtypeindex>();

    public virtual ICollection<V1Workflowtypestartactivitiesindex> V1Workflowtypestartactivitiesindices { get; set; } = new List<V1Workflowtypestartactivitiesindex>();
}
